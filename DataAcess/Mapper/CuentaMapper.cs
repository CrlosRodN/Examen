using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class CuentaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_TIPO = "TIPO";
        private const string DB_COL_FECHA_APERTURA = "FECHA_APERTURA";
        private const string DB_COL_SALDO = "SALDO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ACCOUNT_PR" };

            var a = (Cuenta)entity;
            operation.AddVarcharParam(DB_COL_ID, a.id);
            operation.AddVarcharParam(DB_COL_NOMBRE, a.nombre);
            operation.AddVarcharParam(DB_COL_TIPO, a.tipo);
            operation.AddDateParam(DB_COL_FECHA_APERTURA, a.fechaApert);
            operation.AddDoubleParam(DB_COL_SALDO, a.saldo);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ACCOUNT_PR" };

            var a = (Cuenta)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ACCOUNT_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ACCOUNT_PR" };

            var a = (Cuenta)entity;
            operation.AddVarcharParam(DB_COL_ID, a.id);
            operation.AddVarcharParam(DB_COL_NOMBRE, a.nombre);
            operation.AddVarcharParam(DB_COL_TIPO, a.tipo);
            operation.AddDateParam(DB_COL_FECHA_APERTURA, a.fechaApert);
            operation.AddDoubleParam(DB_COL_SALDO, a.saldo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_ACCOUNT_PR" };

            var a = (Cuenta)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var cuenta = BuildObject(row);
                lstResults.Add(cuenta);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var cuenta = new Cuenta
            {
                Id = GetStringValue(row, DB_COL_ID),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Tipo = GetStringValue(row, DB_COL_TIPO),
                FechaApert = GetDateValue(row, DB_COL_FECHA_APERTURA),
                Saldo = GetDoubleValue(row, DB_COL_SALDO)
            };

            return cuenta;
        }

    }
}
