using LibraryDAL.Context;
using LibraryDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.repo.PublicationRepsoitory
{
    public class BranchRepository
    {
        private readonly LibraryContext _context;

        public BranchRepository(LibraryContext context)
        {
            _context = context;
        }

        public bool BranchExists(string branchName)
        {
            return _context.Branches.Any(p => p.BranchName == branchName);
        }

        public int GetBranchIdByName(string branchName)
        {
            var branch = _context.Branches
                .FirstOrDefault(b => b.BranchName.ToLower() == branchName.ToLower());

            return branch?.BranchId ?? -1;
        }

        public void AddNewBranch(Branch branch)
        {
            _context.Branches.Add(branch);
        }
    }
}
