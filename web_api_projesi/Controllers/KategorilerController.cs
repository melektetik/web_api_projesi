
using Microsoft.AspNetCore.Mvc;
using web_api_projesi.Models;
using web_api_projesi.Data;
using Microsoft.EntityFrameworkCore;

namespace web_api_projesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorilerController : ControllerBase
    {
        private readonly webAPIDbContext _dbContext;
        private object? kategoriDb;

        public KategorilerController(webAPIDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        public async Task<IActionResult> KategoriEkle(
            [FromBody] Kategori kategori)
        {
            if (kategori == null)
            {
                return BadRequest();
            }

            _dbContext.Kategoriler.Add(kategori);
            await _dbContext.SaveChangesAsync();

            return Ok(kategori);
        }
        [HttpGet]
        public async Task<IActionResult> KategorileriGetir()
        {
            var kategoriler = await _dbContext.Kategoriler.ToListAsync();
            return Ok(kategoriler);

        }
        [HttpGet("getKategoriById")]
        public async Task<IActionResult> getKategoriById(int kategoriId)

        {
            var kategori = await _dbContext.Kategoriler.FindAsync(kategoriId);
            if (kategori == null)
            {
                return NotFound();
            }
            return Ok(kategori);

        }
        [HttpPut("{KategoriId}")]
        public async Task<IActionResult> KategoriGuncelle(int KategoriId,Kategori guncelleKategori)
        {
            var kategori = await _dbContext.Kategoriler.FindAsync(KategoriId);
            if (kategori == null)
            {
                return NotFound();
            }

            kategori.KategoriAdi = guncelleKategori.KategoriAdi;
            // Diğer alanları da güncellemek isterseniz burada yapabilirsiniz

            await _dbContext.SaveChangesAsync();

            return Ok(kategori);
        }
        [HttpDelete]
        public async Task<IActionResult> KategoriSil(int kategoriId)
        {
            var kategori = await _dbContext.Kategoriler.FindAsync(kategoriId);
            if (kategori == null)
            {
                return NotFound();
            }
            _dbContext.Kategoriler.Remove(kategori);
            await _dbContext.SaveChangesAsync();
            return Ok(kategoriDb);
        }

        
        }
    }


