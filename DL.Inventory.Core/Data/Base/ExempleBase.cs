using System.Collections.Generic;
using DL.Inventory.Core.Model;
using System.Data;
using DL.Inventory.Core.DAL;

namespace DL.Inventory.Core.Data
{
    public class ExempleBase
    {
        #region Constructor
        public ExempleBase()
        {

        }
        #endregion

        #region Methods
        public IList<Exemple> GetAllExemple()
        {
            #region String SQL
            string sqlExec = "SELECT ExempleID, ExempleName, ExempleDescript, ExempleInsertDate FROM Exemple WHERE ExempleID < 100";
            #endregion
            //IList<ExempleTO> response = ConSqlServerDAL<ExempleTO>.Instance.Teste2(sqlExec);
            //DataSet response2 = ConSqlServerDAL<ExempleTO>.Instance.ExecuteSQL(sqlExec);
            //var teste = DbBase.GetInstance().GetAll(new Exemple { });
            IList<Exemple> response = ConSqlServerDAL<Exemple>.Instance.ExecuteSQL(sqlExec);
            return response;
        }

        public IList<Exemple> GetByFilter(Exemple exemple)
        {
            #region String SQL
            string sqlExec = "SELECT ExempleID, ExempleName, ExempleDescript, ExempleInsertDate FROM Exemple WHERE \n" +
                "(ExempleID = " + exemple.ExempleID + " OR " + exemple.ExempleID + " = 0) AND" +
                "(ExempleName = '" + exemple.ExempleName + "' OR " + exemple.ExempleName + "' = NULL) AND" +
                "(ExempleDescript = '" + exemple.ExempleDescript + "' OR " + exemple.ExempleDescript + "' = NULL) AND" +
                "(ExempleInsertDate = '" + exemple.ExempleInsertDate + "' OR " + exemple.ExempleInsertDate + "' = NULL)";
            #endregion
            IList<Exemple> response = ConSqlServerDAL<Exemple>.Instance.ExecuteSQL(sqlExec);
            return response;
        }

        public Exemple GetExempleById(int id)
        {
            #region Sring SQL
            string sqlExec = "SELECT ExempleID, ExempleName, ExempleDescript, ExempleInsertDate FROM Exemple WHERE ExempleID = "+ id +"";
            #endregion
            IList<Exemple> response = ConSqlServerDAL<Exemple>.Instance.ExecuteSQL(sqlExec);
            return response[0];
        }

        public void CreateExemple(Exemple exemple)
        {
            #region String SQL
            string sqlExec = "INSERT INTO Exemple (ExempleName,ExempleDescript,ExempleInsertDate) VALUES " +
                "('"+exemple.ExempleName+"','"+exemple.ExempleDescript+"','"+exemple.ExempleInsertDate+"')";
            #endregion
            ConSqlServerDAL<Exemple>.Instance.ExecuteSQL(sqlExec);
            //var teste = DbBase.GetInstance().GetAll(exemple);
        }

        public void UpdateExemple(Exemple exemple)
        {
            #region String SQL
            string sqlExec = "UPDATE Exemple SET ExempleName = '" + exemple.ExempleName + "', " +
                " ExempleDescript = '" + exemple.ExempleDescript + "', ExempleInsertDate = '" + exemple.ExempleInsertDate + "' WHERE " +
                " ExempleID = " + exemple.ExempleID + " ";
            #endregion
            ConSqlServerDAL<Exemple>.Instance.ExecuteSQL(sqlExec);
        }

        public void DeleteExemple(int id)
        {
            #region String SQL
            string sqlExec = "DELETE FROM Exemple WHERE ExempleID = "+id;
            #endregion
            ConSqlServerDAL<Exemple>.Instance.ExecuteSQL(sqlExec);
        }

        public void Dispose()
        {

        }
        #endregion

    }
}
