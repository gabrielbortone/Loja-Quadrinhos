using Loja_Quadrinhos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Loja_Quadrinhos.Context
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {

    }
}
