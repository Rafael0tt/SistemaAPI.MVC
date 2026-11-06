using Microsoft.AspNetCore.Mvc;
using MinhaApiMvc.Models;

namespace MinhaApiMvc.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>();
        private static int _nextId = 1;

        // 1. LISTAR TODOS (Exibe a tela princial com a lista).
        public IActionResult Index()
        {
            return View(_products);
        }

        // 2. TELA DE CADASTRO (GET).
        public IActionResult Create()
        {
            return View();
        }

        // 3. SALVAR CADASTRO (POST).
        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
            return RedirectToAction(nameof(Index));
        }

        // 4. BUSCARE PELO ID E EDITARE (GET).
        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);   
        }

        // 5. ATUALIZAR (POST).
        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (product == null) return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            
            return RedirectToAction(nameof(Index));
        }

        // 6. DELETAR (GET).
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}