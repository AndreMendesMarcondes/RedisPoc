using System;
using System.Threading.Tasks;

namespace Redis.Repository
{
    public interface NarutoJutsuRepository
    {
        Task<String> Jutsu();
    }
}
