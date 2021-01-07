using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using System.Threading.Tasks;

namespace ChatBot
{
    public class QnAService
    {
        public string EndPoint { get; set; }
        public string Key { get; set; }
        public string Id { get; set; }

        private QnAMakerRuntimeClient cliente;

        public QnAService(string endPoint, string key, string id)
        {
            EndPoint = endPoint;
            Key = key;
            Id = id;
            cliente = new QnAMakerRuntimeClient(new EndpointKeyServiceClientCredentials(Key)) { RuntimeEndpoint = EndPoint };
        }

        public async Task<string> GenerarRespuesta(string pregunta)
        {
            QnASearchResultList response = await cliente.Runtime.GenerateAnswerAsync(Id, new QueryDTO { Question = pregunta });
            return response.Answers[0].Answer;
        }
    }
}
