using ApiPeliculas.Data;
using ApiPeliculas.Modelos;
using ApiPeliculas.Repositorio.IRepositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiPeliculas.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _bd;

        public CategoriaRepositorio(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarCategoria(Categoria categoria)
        {
            categoria.Fecha = DateTime.Now;
            _bd.Categoria.Update(categoria);
            return Guardar();
        }

        public bool BorrarCategoria(Categoria categoria)
        {
            _bd.Categoria.Remove(categoria);
            return Guardar();
        }

        public bool CrearCategoria(Categoria categoria)
        {
            categoria.Fecha = DateTime.Now;
            _bd.Categoria.Add(categoria);
            return Guardar();
        }

        public bool ExisteCategoria(string nombre)
        {
            bool valor = _bd.Categoria.Any(x => x.Name.ToLower().Trim() = nombre.ToLower().Trim());
            return valor;
        }

        public bool ExisteCategoria(int categoriaId)
        {
            bool valor = _bd.Categoria.Any(x => x.Id.Equals(categoriaId));
            return valor;
        }

        public Categoria GetCategoria(int categoriaId)
        {
            return _bd.Categoria.FirstOrDefault(x => x.Id.Equals(categoriaId));
        }

        public ICollection<Categoria> GetCategorias()
        {
            return _bd.Categoria.ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
