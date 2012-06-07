//Данный интерфейс называется контрактом сервиса, 
//птомучто он декларирует точное описание методов, 
//которые будет предоставлять своим клиентам WCF сервис
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
namespace WCF_DataAccess
{
    [ServiceContract]
    public interface IDbService
    {
        [OperationContract]
        int GetId(string NameWord);
        [OperationContract]
        string GetWord(int Id);
    }
}