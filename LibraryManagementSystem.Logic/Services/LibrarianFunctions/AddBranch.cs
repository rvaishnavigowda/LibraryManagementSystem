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
    public class AddBranch
    {
        private readonly UnitOfWork _unitOfWork;

        public AddBranch()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int AddB(string branchName)
        {
            try
            {
                if (_unitOfWork.BranchRepository.BranchExists(branchName.ToLower()))
                {
                    return -1;
                }

                _unitOfWork.BranchRepository.AddNewBranch(new Branch
                {
                    BranchName = branchName.ToLower()
                });

                _unitOfWork.Save();

                return 1;
            }
            catch (Exception)
            {
                return -2; 
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }
    }
}
