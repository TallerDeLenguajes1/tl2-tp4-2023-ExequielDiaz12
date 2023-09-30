using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaAPI.models;
using CadeteriaAPI.Repositories;

namespace CadeteriaAPI.Repositories
{
    public interface ICadeteRepository
    {
        IEnumerable<Cadete> GetAllCadetes();
        Cadete GetCadete(int id);
        void CreateCadete(Cadete cadete);
        bool UpdateCadete(int id, Cadete cadete);
        bool DeleteCadete(int id);
    }
}