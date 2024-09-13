using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GF.ControleAcesso.Domain.Entities;

namespace GF.ControleAcesso.Domain.Interfaces.Services;

public interface ISignInService
{
    SignInResponse SignIn(Usuario request);
}
