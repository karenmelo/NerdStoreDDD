using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.DTO;
using NerdStore.Catalogo.Application.Services.Interfaces;

namespace NerdStore.WebApp.MVC.Controllers.Admin
{
    public class AdminProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        public AdminProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }
        /// <summary>
        /// Carrega a página de produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("admin-produtos")]
        public async Task<IActionResult> Index()
        {
            return View(await _produtoAppService.ObterTodos());
        }

        /// <summary>
        ///  Criação de um novo produto
        /// </summary>
        /// <returns></returns>
        [Route("novo-produto")]
        public async Task<IActionResult> NovoProduto()
        {
            return View(await PopularCategorias(new ProdutoDTO()));
        }

        /// <summary>
        /// Post de criação do produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("novo-produto")]
        public async Task<IActionResult> NovoProduto(ProdutoDTO produto)
        {
            if (!ModelState.IsValid) return View(await PopularCategorias(produto));

            await _produtoAppService.AdicionarProduto(produto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("editar-produto")]
        public async Task<IActionResult>AtualizarProduto(Guid id)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            var produtoCompleto = await PopularCategorias(produto);
            return View(produtoCompleto);
         }

        [HttpPost]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id, ProdutoDTO produtoViewModel)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            produtoViewModel.QuantidadeEstoque = produto.QuantidadeEstoque;

            ModelState.Remove("QuantidadeEstoque");
            if (!ModelState.IsValid) return View(await PopularCategorias(produtoViewModel));

            await _produtoAppService.AtualizarProduto(produtoViewModel);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Carrega a pagina de Estoque
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id)
        {
            return View("Estoque", await _produtoAppService.ObterPorId(id));
        }

        /// <summary>
        /// Post de atualização de estoque
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id, int quantidade)
        {
            if (quantidade > 0)
                await _produtoAppService.ReporEstoque(id, quantidade);
            else
                await _produtoAppService.DebitarEstoque(id, quantidade);

            return View("Index", await _produtoAppService.ObterTodos());
        }

        /// <summary>
        /// Método para popular categorias cadastras
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        private async Task<ProdutoDTO> PopularCategorias(ProdutoDTO produto)
        {
            produto.Categorias = await _produtoAppService.ObterCategorias();
            return produto;
        }
    }
}
