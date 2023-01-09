using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.Directory.Any())
            {
                context.Directory.Add(new Entities.Directory() { Title = "First Directory", Html = "<b>Directory Content</b>" });
                context.Directory.Add(new Entities.Directory() { Title = "Second Directory", Html = "<b>Directory Content</b>" });
                context.SaveChanges();  
                context.Material.Add(new Entities.Material() { Title = "First Material", Html = "<i>Material Content</i>", DirectoryId = context.Directory.First().Id });
                context.Material.Add(new Entities.Material() { Title = "Last Material", Html = "<i>Material Content</i>", DirectoryId = context.Directory.Last().Id });
                context.SaveChanges();
            }
        }
    }
}
