using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class CreditoMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_MONTO = "MONTO";
        private const string DB_COL_TASA = "TASA";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_CUOTA = "CUOTA";
        private const string DB_COL_FECHA_INICIO = "FECHA_INICIO";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_SALDO = "SALDO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CREDIT_PR" };

            var c = (Credito)entity;
            operation.AddVarcharParam(DB_COL_ID, c.id);
            operation.AddDoubleParam(DB_COL_MONTO, c.monto);
            operation.AddDoubleParam(DB_COL_TASA, c.tasa);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.nombre);
            operation.AddDoubleParam(DB_COL_CUOTA, c.cuota);
            operation.AddDateParam(DB_COL_FECHA_INICIO, c.fechaInicio);
            operation.AddVarcharParam(DB_COL_ESTADO, c.estado);
            operation.AddDoubleParam(DB_COL_SALDO, c.saldo);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CREDIT_PR" };

            var c = (Credito)entity;
            operation.AddVarcharParam(DB_COL_ID, c.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CREDIT_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CREDIT_PR" };

            var c = (Credito)entity;
            operation.AddVarcharParam(DB_COL_ID, c.Id);
            operation.AddDoubleParam(DB_COL_MONTO, c.Monto);
            operation.AddDoubleParam(DB_COL_TASA, c.Tasa);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddDoubleParam(DB_COL_CUOTA, c.Cuota);
            operation.AddDateParam(DB_COL_FECHA_INICIO, c.FechaInicio);
            operation.AddVarcharParam(DB_COL_ESTADO, c.Estado);
            operation.AddDoubleParam(DB_COL_SALDO, c.Saldo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CREDIT_PR" };

            var c = (Credito)entity;
            operation.AddVarcharParam(DB_COL_ID, c.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var credito = new Credito
            {
                Id = GetStringValue(row, DB_COL_ID),
                Monto = GetDoubleValue(row, DB_COL_MONTO),
                Tasa = GetDoubleValue(row, DB_COL_TASA),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Cuota = GetDoubleValue(row, DB_COL_CUOTA),
                FechaInicio = GetDateValue(row, DB_COL_FECHA_INICIO),
                Estado = GetStringValue(row, DB_COL_ESTADO),
                Saldo = GetDoubleValue(row, DB_COL_SALDO)
            };

            return credito;
        }

    }
}
