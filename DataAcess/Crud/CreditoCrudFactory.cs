using DataAcess.Dao;
using DataAcess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAcess.Crud
{
    public class CreditoCrudFactory : CrudFactory
    {
        CreditoMapper mapper;

        public CreditoCrudFactory() : base()
        {
            mapper = new CreditMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var credito = (Credito)entity;
            var sqlOperation = mapper.GetCreateStatement(credito);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveStatement(entity);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var listaCredito = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    listaCredito.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listaCredito;
        }

        public override void Update(BaseEntity entity)
        {
            var credito = (Credito)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(credit));
        }

        public override void Delete(BaseEntity entity)
        {
            var credito = (Credito)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(credit));
        }

    }
}
