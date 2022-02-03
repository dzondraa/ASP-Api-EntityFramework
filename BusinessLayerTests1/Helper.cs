using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerTests1
{
    
    public static class Helper
    {
        /// <summary>
        /// Nasa metoda u helper klasi <see cref="Helper"/> koja pravi in memory (laznu) bazu
        /// </summary>
        public static OurContext GetFakeMemoryDB()
        {
            var options = new DbContextOptionsBuilder<OurContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            return new OurContext(options);
        }
    }
}
