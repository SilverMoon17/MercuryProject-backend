using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Infrastructure.Authentication
{
    public class HashSettings
    {
        public const string SectionName = "HashSettings";
        public string Key { get; init; } = null!;
    }
}
