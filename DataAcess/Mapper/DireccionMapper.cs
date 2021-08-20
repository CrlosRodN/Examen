using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class DireccionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_PROVINCIA = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRITO = "DISTRITO";
        private const string DB_COL_DIRECCION = "SENNAS";
        private const string DB_COL_TIPO = "TIPO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_DIRECCION_PR" };

            var a = (Direccion)entity;
            operation.AddVarcharParam(DB_COL_ID, a.id);
            operation.AddVarcharParam(DB_COL_PROVINCIA, a.provincia);
            operation.AddVarcharParam(DB_COL_CANTON, a.canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, a.distrito);
            operation.AddVarcharParam(DB_COL_DIRECCION, a.direccion);
            operation.AddVarcharParam(DB_COL_TIPO, a.tipo);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DIRECCION_PR" };

            var a = (Direccion)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_DIRECCION_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_DIRECCION_PR" };

            var a = (Direccion)entity;
            operation.AddVarcharParam(DB_COL_ID, a.id);
            operation.AddVarcharParam(DB_COL_PROVINCIA, a.provincia);
            operation.AddVarcharParam(DB_COL_CANTON, a.canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, a.distrito);
            operation.AddVarcharParam(DB_COL_DIRECCION, a.direccion);
            operation.AddVarcharParam(DB_COL_TIPO, a.tipo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_DIRECCION_PR" };

            var a = (Direccion)entity;
            operation.AddVarcharParam(DB_COL_ID, a.id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var direccion = BuildObject(row);
                lstResults.Add(direccion);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var direccion = new Direccion
            {
                Id = GetStringValue(row, DB_COL_ID),
                Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                Canton = GetStringValue(row, DB_COL_CANTON),
                Distrito = GetStringValue(row, DB_COL_DISTRITO),
                Sennas = GetStringValue(row, DB_COL_DIRECCION),
                Tipo = GetStringValue(row, DB_COL_TIPO)
            };

            return direccion;
        }
    }
}
