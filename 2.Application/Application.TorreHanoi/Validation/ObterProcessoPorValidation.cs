using Application.TorreHanoi.Message;
using System;

namespace Application.TorreHanoi.Validation
{
    internal static class ObterProcessoPorValidation
    {
        private static Guid guid;

        internal static ObterProcessoPorResponse ValidationProcesso(this string id)
        {
            var response = new ObterProcessoPorResponse();

            if (Guid.TryParse(id, out guid))
            {
                return response;
            }
            response.AdicionarMensagemDeErro($"É o id {id} não esta em um formato valido");
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;

            return response;
        }
    }
}
