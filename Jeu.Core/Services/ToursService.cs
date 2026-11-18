using Jeu.Core.Domain;
using Jeu.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Services
{
    public class ToursService : IToursService
    {

        protected IToursRepository ToursRepository { get; }

        public ToursService(IToursRepository toursRepository)
        {
            ToursRepository = toursRepository;
        }
        public Tours Obtenir(int id)
        {
            return ToursRepository.Obtenir(id);
        }

        public List<Tours> ObtenirTous(int id)
        {
            return ToursRepository.ObtenirTous(id);
        }


        public void Ajouter(Tours tours, int save)
        {
            ToursRepository.Ajouter(tours, save);
        }

        public void Supprimer(int id)
        {
            ToursRepository.Supprimer(id);
        }

        public bool Existe(int id)
        {
            return ToursRepository.Existe(id);
        }
    }
}
