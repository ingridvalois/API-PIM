using System.Security.Cryptography.X509Certificates;
using API_PIM.Application.Services;
using API_PIM.Controllers;
using API_PIM.Infrastructure.DAO;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class FolhaPagamentoController : ControllerBase
{

    public FolhaPagamentoController(IConfiguration configuration, AuthenticatedUser authenticatedUser)
    {
        _configuration = configuration;
        _authenticatedUser = authenticatedUser;
       _folhaPagamentoDAO = new FolhaPagamentoDAO(_configuration);

    }

    private readonly IConfiguration _configuration;
    private readonly AuthenticatedUser _authenticatedUser;

    private readonly FolhaPagamentoDAO _folhaPagamentoDAO;

    [HttpGet("test-connection")]
    public IActionResult TestConnection()
    {
        TestFolhaPagamento _testFolhaPagamento = new TestFolhaPagamento(_configuration);

        bool isConnected = _testFolhaPagamento.TestDatabaseConnection();

        if (isConnected)
        {
            return Ok("Conexão com o banco de dados bem-sucedida.");
        }
        else
        {
            return BadRequest("Não foi possível estabelecer a conexão com o banco de dados.");
        }
    }

    [HttpGet("getfolhapagamento")]
    public IActionResult FolhaPagamento()
    {
        
        return Ok(_folhaPagamentoDAO.ListFolhaPagamento());
    }

    [HttpGet("usuario")]
    public IActionResult FolhaPagamentoU()
    {
        return Ok(_folhaPagamentoDAO.ListFolhaPagamentoU(int.Parse(_authenticatedUser.IdPessoa)));
    }

}

