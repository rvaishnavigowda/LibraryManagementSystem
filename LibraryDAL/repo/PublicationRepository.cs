using LibraryDAL.Context;
using LibraryDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.repo.PublicationRepsoitory
{
    public class PublicationRepository
    {
        private readonly LibraryContext _context;

        public PublicationRepository(LibraryContext context)
        {
            _context = context;
        }

        public bool PublicationExists(string publicationName)
        {
            return _context.Publications.Any(p => p.PublicationName == publicationName);
        }

        public int GetPublicationIdByName(string publicationName)
        {
            var publication = _context.Publications
                .FirstOrDefault(p => p.PublicationName.ToLower() == publicationName.ToLower());

            return publication?.PublicationId ?? -1;
        }

        public void AddNewPublication(Publication publication)
        {
            _context.Publications.Add(publication);
        }
    }
}
