using LibraryDAL.Models;
using LibraryDAL.repo;
using LibraryDAL.unitofwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Logic
{
    public class AddPublication
    {
        private readonly UnitOfWork _unitOfWork;

        public AddPublication()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int AddP(string publicationName)
        {
            if (_unitOfWork.PublicationRepository.PublicationExists(publicationName.ToLower()))
            {
                _unitOfWork.Dispose();
                return -1;
            }

            _unitOfWork.PublicationRepository.AddNewPublication(new Publication
            {
                PublicationName = publicationName.ToLower()
            });

            _unitOfWork.Save();
            _unitOfWork.Dispose();

            return 1;
        }
    }
}
    
