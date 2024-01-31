
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace SBOAddOn_TSA
{

    [FormAttribute("SBOAddOn_TSA.NewForm_1_b1f", "Forms/NewForm 1.b1f")]
    class NewForm_1_b1f : UserFormBase
    {
        public NewForm_1_b1f()
        {
            //try
            //{
            //    oForm = Application.SBO_Application.Forms.Item("BIZD.Form1");

            //    Application.SBO_Application.MessageBox(oForm.Title.ToString());
            //}
            //catch (Exception ex)
            //{

            //    Application.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            //}
        }

        private SAPbouiCOM.IForm oForm;
        private SAPbouiCOM.IItem oItem;

        SAPbouiCOM.StaticText oStaticTxt = null;
        SAPbouiCOM.EditTextColumn oEditColumn;
        SAPbouiCOM.CheckBoxColumn oCheckBox;
        SAPbouiCOM.BoGridColumnType oGridColType;

        SAPbouiCOM.DataTable oDatatable1;
        SAPbouiCOM.DataTable oDatatable2;

        //Create Delcare Interface UI Button
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button3;
        private SAPbouiCOM.Button Button4;

        //Create Delcare Interface UI Button
        private SAPbouiCOM.CheckBox Check0;

        //
        private SAPbouiCOM.IMatrix oMatrix_User;
        //
        private SAPbouiCOM.IColumn oColumn;
        //
        SAPbouiCOM.EditText UserValueID;
        SAPbouiCOM.EditText UserValueNum;
        SAPbouiCOM.EditText UserValueStr;

        private string UserID = null;
        private string UserCode=null;
        private string UserName=null;
        //
        public SAPbouiCOM.DBDataSource oDBDataSource1;        

        private SAPbouiCOM.DataTable oDataTable;

        public SAPbobsCOM.Company oCompany;
        //
        //private SAPbouiCOM.Condition oCon;
        //private SAPbouiCOM.Conditions oCons;

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_can").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_ok").Specific));
            this.Button1.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button1_ClickBefore);
            this.Check0 = ((SAPbouiCOM.CheckBox)(this.GetItem("item_hide").Specific));
            this.Check0.ClickBefore += this.Check0_ClickBefore1;
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("item_lu").Specific));
            this.Matrix0.ClickBefore += new SAPbouiCOM._IMatrixEvents_ClickBeforeEventHandler(this.Matrix0_ClickBefore);
            //              this.Matrix0.DoubleClickBefore += new SAPbouiCOM._IMatrixEvents_DoubleClickBeforeEventHandler(this.Matrix0_DoubleClickBefore);
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_1").Specific));
            this.Button3.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button3_ClickBefore);
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("Item_3").Specific));
            this.Button4.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button4_ClickBefore);
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_gsu").Specific));
            this.Grid0.ClickBefore += new SAPbouiCOM._IGridEvents_ClickBeforeEventHandler(this.Grid0_ClickBefore);
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_T1").Specific));
            this.OnCustomInitialize();

        }

        // *** Event Click On Check Box ***
        private void Check0_ClickBefore1(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                oForm = Application.SBO_Application.Forms.ActiveForm;

                Check0.ValOff = "N";
                Check0.ValOn = "Y";

                oDBDataSource1 = oForm.DataSources.DBDataSources.Add("OUSR");

                Check0.DataBind.SetBound(true, "OUSR", "Locked");
                          
                oForm.DataSources.UserDataSources.Item("DS_chk_1").Value = "Y";

                if (Check0.Checked == true)
                {
                    oItem = oForm.Items.Item("item_lu");

                    oMatrix_User = (SAPbouiCOM.IMatrix)(oItem.Specific);

                    oMatrix_User.Clear();

                    oColumn = oMatrix_User.Columns.Item("Col_0");
                    oColumn.DataBind.Bind("DT_OUSR1", "USER_CODE");

                    oColumn = oMatrix_User.Columns.Item("Col_1");
                    oColumn.DataBind.Bind("DT_OUSR1", "U_NAME");

                    oColumn = oMatrix_User.Columns.Item("Col_2");
                    oColumn.DataBind.Bind("DT_OUSR1", "USERID");

                    oColumn = oMatrix_User.Columns.Item("Col_3");
                    oColumn.DataBind.Bind("DT_OUSR1", "Locked");

                    oMatrix_User.LoadFromDataSource();

                }
                else
                {
                    oItem = oForm.Items.Item("item_lu");

                    oMatrix_User = (SAPbouiCOM.IMatrix)(oItem.Specific);

                    oMatrix_User.Clear();

                    oColumn = oMatrix_User.Columns.Item("Col_0");
                    oColumn.DataBind.Bind("DT_OUSR2", "USER_CODE");

                    oColumn = oMatrix_User.Columns.Item("Col_1");
                    oColumn.DataBind.Bind("DT_OUSR2", "U_NAME");

                    oColumn = oMatrix_User.Columns.Item("Col_2");
                    oColumn.DataBind.Bind("DT_OUSR2", "USERID");

                    oColumn = oMatrix_User.Columns.Item("Col_3");
                    oColumn.DataBind.Bind("DT_OUSR2", "Locked");

                    oMatrix_User.LoadFromDataSource();
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage(ex.Message,SAPbouiCOM.BoMessageTime.bmt_Short,true);
            }
        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            //oCompany.Server = "192.168.1.11:30015";
            //oCompany.LicenseServer = "192.168.1.11:40001";
            //oCompany.CompanyDB = "TLTELA_DEVELOEPR";
            //oCompany.UserName = "manager10";
            //oCompany.Password = "123123";
            //oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;
            //oCompany.DbUserName = "SYSTEM";
            //oCompany.DbPassword = "Biz@2022";
            //oCompany.UseTrusted = true;
            //oCompany.Connect();
        }        

        // *** Event Click Close Button ***
        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.ActiveForm;
                oForm.Close();
            }
            catch (Exception  ex)
            {
                Application.SBO_Application.SetStatusBarMessage(ex.Message,SAPbouiCOM.BoMessageTime.bmt_Short,true);
            }

        }

        // *** Event Click OK Button ***
        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            string QueryInsert = null;
            string QueryRemove = null;
            string QuerySelect = "SELECT * FROM OINV";

            int i = 0;           

            try
            {
                if (pVal.ItemUID=="OK")
                {                   
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.ActiveForm;
                    oForm.Close();
                }
                else
                {
                    oCompany = new SAPbobsCOM.Company();
                    oCompany = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany();
                    SAPbobsCOM.Recordset oRecordSet = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);                 
                    oRecordSet.DoQuery(QuerySelect);

                    //if (!oRecordSet.EoF)
                    //{
                    //    oRecordSet.MoveNext();
                    //    i = i + 1;
                    //}
                    //oRecordSet = null;
                }
                Application.SBO_Application.MessageBox(i.ToString());                                      
            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }

        }

        private void OnCustomInitialize()
        {
            try
            {
                DTLoad();
                GrideLoad();
                LoadUser();
                //LoadSubject();            
            }
            catch (Exception ex)
            {
                oForm.Close();
                Application.SBO_Application.SetStatusBarMessage(ex.Message,SAPbouiCOM.BoMessageTime.bmt_Short,true);                
            }
        }

        private void LoadUser()
        {
            try
            {
                //
                oForm = Application.SBO_Application.Forms.Item("NewForm1");
                //
                oItem = oForm.Items.Item("item_lu");
                //
                oMatrix_User = ((SAPbouiCOM.IMatrix)(oItem.Specific));
                //
                oColumn = oMatrix_User.Columns.Item("Col_0");                
                oDBDataSource1 = oForm.DataSources.DBDataSources.Add("OUSR");
                oColumn.DataBind.SetBound(true,"OUSR","USER_CODE");
                oColumn.Width = 200;

                oColumn = oMatrix_User.Columns.Item("Col_1");
                oDBDataSource1 = oForm.DataSources.DBDataSources.Add("OUSR");
                oColumn.DataBind.SetBound(true, "OUSR", "U_NAME");
                oColumn.Visible = false;

                oColumn = oMatrix_User.Columns.Item("Col_2");
                oDBDataSource1 = oForm.DataSources.DBDataSources.Add("OUSR");
                oColumn.DataBind.SetBound(true, "OUSR", "USERID");
                oColumn.Visible = false;

                oColumn = oMatrix_User.Columns.Item("Col_3");
                oDBDataSource1 = oForm.DataSources.DBDataSources.Add("OUSR");
                oColumn.DataBind.SetBound(true, "OUSR", "Locked");
                oColumn.Visible = false;

                oDBDataSource1.Query(null);
                //
                oMatrix_User.LoadFromDataSource();
                //
                oColumn = oMatrix_User.Columns.Item("Col_0");
                oColumn.TitleObject.Sort(SAPbouiCOM.BoGridSortType.gst_Ascending);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }            
        }

        private void LoadSubject()
        {            
            //
            oForm = Application.SBO_Application.Forms.Item("NewForm1");
            //
            oItem = oForm.Items.Item("item_su");
            //
            oMatrix_User = (SAPbouiCOM.IMatrix)(oItem.Specific);
            //
            //oDataTable = oForm.DataSources.DataTables.Add("DT_OUPT");
            //oDataTable.ExecuteQuery("SELECT * FROM OUPT ORDER BY \"VisOrder\"");
            //            
            oColumn = oMatrix_User.Columns.Item("Col_0");
            //
            oColumn = oMatrix_User.Columns.Item("Col_1");
            oColumn.DataBind.Bind("DT_OUPT", "Absid");            

            oColumn = oMatrix_User.Columns.Item("Col_2");
            oColumn.DataBind.Bind("DT_OUPT", "SUB_NAME");
            //oColumn.DataBind.Bind("DT_OUPT", "Name");

            oColumn = oMatrix_User.Columns.Item("Col_3");
            oColumn.Editable = true;

            //oColumn = oMatrix_User.Columns.Item("Col_6");
            //oColumn.Editable = true;

            oColumn = oMatrix_User.Columns.Item("Col_6");
            oColumn.DataBind.Bind("DT_OUPT", "Fathid");

            oColumn = oMatrix_User.Columns.Item("Col_8");
            oColumn.DataBind.Bind("DT_OUPT", "Levels");

            oColumn = oMatrix_User.Columns.Item("Col_9");
            oColumn.DataBind.Bind("DT_OUPT", "IsItem");

            oMatrix_User.LoadFromDataSource();
        }

        private void DTLoad()
        {
            oForm = Application.SBO_Application.Forms.Item("NewForm1");

            oDataTable = oForm.DataSources.DataTables.Add("DT_OUSR1");
            oDataTable.ExecuteQuery("SELECT \"USER_CODE\",\"U_NAME\",\"USERID\",\"Locked\" FROM OUSR ORDER BY \"USER_CODE\"");

            oDataTable = oForm.DataSources.DataTables.Add("DT_OUSR2");
            oDataTable.ExecuteQuery("SELECT \"USER_CODE\",\"U_NAME\",\"USERID\",\"Locked\" FROM OUSR WHERE \"Locked\"='N' ORDER BY \"USER_CODE\"");

            oDataTable = oForm.DataSources.DataTables.Add("DT_OUPT");
            //oDataTable.ExecuteQuery("SELECT * FROM OUPT ORDER BY \"VisOrder\"");

            //oDataTable.ExecuteQuery("SELECT *,CASE WHEN \"Levels\" = '1' THEN \"Name\" WHEN \"Levels\" = '2' THEN CHAR(9) || \"Name\" WHEN \"Levels\" = '3' THEN '|     ' || '     ' || \"Name\" WHEN \"Levels\" = '4' THEN '-     ' || '     ' || '     ' || \"Name\" WHEN \"Levels\" = '5' THEN '-     ' || '     ' || '     ' || '     ' || \"Name\" END \"SUB_NAME\" FROM OUPT ORDER BY \"VisOrder\"");

            oDataTable.ExecuteQuery("SELECT *, CASE WHEN \"Levels\" = '1' THEN \"Name\" " +
                                    " WHEN \"Levels\" = '2' THEN ROW_NUMBER() OVER(PARTITION BY \"FathId\", \"Levels\" ORDER BY \"VisOrder\" ASC) || '. ' || \"Name\" " +
                                    " WHEN \"Levels\" = '3' THEN '     ' || ROW_NUMBER() OVER(PARTITION BY \"FathId\", \"Levels\" ORDER BY \"VisOrder\" ASC) || '. ' || \"Name\" " +
                                    " WHEN \"Levels\" = '4' THEN '     ' || '     ' || ROW_NUMBER() OVER(PARTITION BY \"FathId\", \"Levels\" ORDER BY \"VisOrder\" ASC) || '. ' || \"Name\" " +
                                    " WHEN \"Levels\" = '5' THEN '     ' || '     ' || '     ' || ROW_NUMBER() OVER(PARTITION BY \"FathId\", \"Levels\" ORDER BY \"VisOrder\" ASC) || '. ' || \"Name\" " +
                                    " END \"SUB_NAME\" FROM OUPT ORDER BY \"VisOrder\" ");
        }

        private SAPbouiCOM.Matrix Matrix0;

        private void Matrix0_DoubleClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
            {
            BubbleEvent = true;
            try
            {               
                //string strValue;

                //oForm = Application.SBO_Application.Forms.Item("NewForm1");
                //oItem = oForm.Items.Item("item_lu");
                //oMatrix_User = (SAPbouiCOM.IMatrix)(oItem.Specific);

                //int selrow1 = oMatrix_User.GetNextSelectedRow(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                //EditValue = (SAPbouiCOM.EditText)oMatrix_User.GetCellSpecific(2, pVal.Row);
                //strValue = EditValue.Value.ToString().Trim();

                //Application.SBO_Application.SetStatusBarMessage(strValue , SAPbouiCOM.BoMessageTime.bmt_Short,true);
            }
            catch (Exception ex )
            {
                Application.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }

        }

        private void Matrix0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                oItem = oForm.Items.Item("Item_ok");
                SAPbouiCOM.Button oButton = (SAPbouiCOM.Button)(oItem.Specific);
                

                if (pVal.ColUID == "Col_4" && oButton.Caption == "OK")
                {
                    
                    //string strValue;                
                    //int yellow = 252 | (221 << 8) | (130 << 16);                        

                    oForm = Application.SBO_Application.Forms.Item("NewForm1");                    

                    oItem = oForm.Items.Item("item_lu");
                    oMatrix_User = (SAPbouiCOM.IMatrix)(oItem.Specific);

                    UserValueID = (SAPbouiCOM.EditText)oMatrix_User.GetCellSpecific(3, pVal.Row);
                    UserValueNum = (SAPbouiCOM.EditText)oMatrix_User.GetCellSpecific(1, pVal.Row);
                    UserValueStr = (SAPbouiCOM.EditText)oMatrix_User.GetCellSpecific(2, pVal.Row);

                    UserID = UserValueID.Value.ToString().Trim();
                    UserCode = UserValueNum.Value.ToString().Trim();
                    UserName = UserValueStr.Value.ToString().Trim();

                    oItem = oForm.Items.Item("Item_T1");                    
                    oStaticTxt = (SAPbouiCOM.StaticText)(oItem.Specific);                    
                    oStaticTxt.Caption = "User ID: "+UserID+", User Code: "+UserCode+", "+"User Name: "+UserName;
                    oItem.Visible = true;

                    string sql =
                        " SELECT " +
                        " C.\"Name\" \"LV2\",IFNULL(D.\"Name\",'') \"LV3\", " +
                        " CASE WHEN G.\"AbsId\" IS NOT NULL THEN 'Y' ELSE 'N' END \"Authorization\" " +
                        " FROM OUPT A " +
                        " LEFT OUTER JOIN(SELECT LEFT(\"AbsId\", 2) \"Code\", \"AbsId\", \"Levels\", \"Name\" FROM OUPT A WHERE \"Levels\" = '1') B ON LEFT(A.\"AbsId\", 2) = B.\"Code\" " +
                        " LEFT OUTER JOIN(SELECT LEFT(\"AbsId\", 4) \"Code\", \"AbsId\", \"Levels\", \"Name\" FROM OUPT A WHERE \"Levels\" = '2') C ON LEFT(A.\"AbsId\", 4) = C.\"Code\" " +
                        " LEFT OUTER JOIN(SELECT LEFT(\"AbsId\", 6) \"Code\", \"AbsId\", \"Levels\", \"Name\" FROM OUPT A WHERE \"Levels\" = '3') D ON LEFT(A.\"AbsId\", 6) = D.\"Code\" " +
                        " LEFT OUTER JOIN(SELECT LEFT(\"AbsId\", 8) \"Code\", \"AbsId\", \"Levels\", \"Name\" FROM OUPT A WHERE \"Levels\" = '4') E ON LEFT(A.\"AbsId\", 8) = E.\"Code\" " +
                        " LEFT OUTER JOIN(SELECT LEFT(\"AbsId\", 10) \"Code\", \"AbsId\", \"Levels\", \"Name\" FROM OUPT A WHERE \"Levels\" = '5') F ON LEFT(A.\"AbsId\", 10) = F.\"Code\" " +
                        " LEFT OUTER JOIN(SELECT * FROM \"TL_AUTHO\" WHERE \"UserID\"='" + UserID.ToString() + "') G ON A.\"AbsId\"=G.\"AbsId\" " +
                        " WHERE A.\"Levels\">'1' AND D.\"Name\" IS NOT NULL " +
                        " ORDER BY \"VisOrder\",G.\"UserID\" ASC ";

                    oItem = oForm.Items.Item("Item_gsu");
                    oItem.Visible = false;
                    SAPbouiCOM.Grid oGrid = (SAPbouiCOM.Grid)(oItem.Specific);                    

                    //oDatatable2 = oForm.DataSources.DataTables.Add("TB_Sub2");
                    oDatatable2 = oForm.DataSources.DataTables.Item("TB_Sub2");
                    oDatatable2.Clear();
                    oDatatable2.ExecuteQuery(sql);
                    
                    oGrid.DataTable = oForm.DataSources.DataTables.Item("TB_Sub2");

                    oGridColType = (SAPbouiCOM.BoGridColumnType)(oGrid.Columns.Item(0).Type);
                    oGridColType = SAPbouiCOM.BoGridColumnType.gct_EditText;
                    oEditColumn = (SAPbouiCOM.EditTextColumn)(oGrid.Columns.Item(0));
                    oEditColumn.TitleObject.Caption = "Subject";
                    oEditColumn.Width = 150;
                    oEditColumn.Editable = false;

                    oGridColType = (SAPbouiCOM.BoGridColumnType)(oGrid.Columns.Item(1).Type);
                    oGridColType = SAPbouiCOM.BoGridColumnType.gct_EditText;
                    oEditColumn = (SAPbouiCOM.EditTextColumn)(oGrid.Columns.Item(1));
                    oEditColumn.TitleObject.Caption = "";
                    oEditColumn.Width = 1500;
                    oEditColumn.Editable = false;

                    oGrid.Columns.Item(2).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
                    oCheckBox = (SAPbouiCOM.CheckBoxColumn)(oGrid.Columns.Item(2));
                    oCheckBox.Editable = true;

                    oGrid.CollapseLevel = 1;
                    oGrid.Rows.ExpandAll();
                    oGrid.AutoResizeColumns();

                    oItem.Visible = true;
                }
                else if (pVal.ColUID == "Col_4" && oButton.Caption == "Update")
                {
                    Application.SBO_Application.MessageBox("Please, Update on "+"User ID: "+UserID+", User Code: "+UserCode+", "+"User Name: "+UserName+".", 2, "OK", "","");             
                }          
            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }

        }

        private void Button3_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.Grid oGrid = null;

                oForm = Application.SBO_Application.Forms.Item("NewForm1");
                oItem = oForm.Items.Item("Item_gsu");
                oGrid = (SAPbouiCOM.Grid)(oItem.Specific);

                oGrid.Rows.CollapseAll();

            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }

        }

        private void GrideLoad()
        {
            string sql =
                        " SELECT " +
                        " C.\"Name\" \"LV2\",IFNULL(D.\"Name\",'') \"LV3\", " +
                        " 'N' \"Authorization\" " +
                        " FROM OUPT A " +
                        " LEFT OUTER JOIN(SELECT LEFT(\"AbsId\", 2) \"Code\", \"AbsId\", \"Levels\", \"Name\" FROM OUPT A WHERE \"Levels\" = '1') B ON LEFT(A.\"AbsId\", 2) = B.\"Code\" " +
                        " LEFT OUTER JOIN(SELECT LEFT(\"AbsId\", 4) \"Code\", \"AbsId\", \"Levels\", \"Name\" FROM OUPT A WHERE \"Levels\" = '2') C ON LEFT(A.\"AbsId\", 4) = C.\"Code\" " +
                        " LEFT OUTER JOIN(SELECT LEFT(\"AbsId\", 6) \"Code\", \"AbsId\", \"Levels\", \"Name\" FROM OUPT A WHERE \"Levels\" = '3') D ON LEFT(A.\"AbsId\", 6) = D.\"Code\" " +
                        " LEFT OUTER JOIN(SELECT LEFT(\"AbsId\", 8) \"Code\", \"AbsId\", \"Levels\", \"Name\" FROM OUPT A WHERE \"Levels\" = '4') E ON LEFT(A.\"AbsId\", 8) = E.\"Code\" " +
                        " LEFT OUTER JOIN(SELECT LEFT(\"AbsId\", 10) \"Code\", \"AbsId\", \"Levels\", \"Name\" FROM OUPT A WHERE \"Levels\" = '5') F ON LEFT(A.\"AbsId\", 10) = F.\"Code\" " +
                        " WHERE A.\"Levels\">'1' AND D.\"Name\" IS NOT NULL " +
                        " ORDER BY \"VisOrder\" ASC ";

            oForm = Application.SBO_Application.Forms.Item("NewForm1");        
            oItem = oForm.Items.Item("Item_gsu");                     

            oDatatable1 =oForm.DataSources.DataTables.Add("TB_Sub");
            oDatatable1.Clear();
            oDatatable1.ExecuteQuery(sql);

            SAPbouiCOM.Grid oGrid = (SAPbouiCOM.Grid)(oItem.Specific);
            oGrid.DataTable = oForm.DataSources.DataTables.Item("TB_Sub");

            oGridColType = (SAPbouiCOM.BoGridColumnType)(oGrid.Columns.Item(0).Type);
            oGridColType = SAPbouiCOM.BoGridColumnType.gct_EditText;
            oEditColumn = (SAPbouiCOM.EditTextColumn)(oGrid.Columns.Item(0));
            oEditColumn.TitleObject.Caption = "Subject";
            oEditColumn.Width = 150;
            oEditColumn.Editable = false;

            oGridColType = (SAPbouiCOM.BoGridColumnType)(oGrid.Columns.Item(1).Type);
            oGridColType = SAPbouiCOM.BoGridColumnType.gct_EditText;
            oEditColumn = (SAPbouiCOM.EditTextColumn)(oGrid.Columns.Item(1));
            oEditColumn.TitleObject.Caption = "";
            oEditColumn.Width = 1500;
            oEditColumn.Editable = false;

            oGrid.Columns.Item(2).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            oCheckBox = (SAPbouiCOM.CheckBoxColumn)(oGrid.Columns.Item(2));
            oCheckBox.Editable = false;            

            oGrid.CollapseLevel=1;
            oGrid.Rows.CollapseAll();
            oGrid.AutoResizeColumns();         

            //if (UserCode == null)
            //{
            //    oEditColumn = (SAPbouiCOM.EditTextColumn)(oGrid.Columns.Item(0));
            //    oEditColumn.Editable = false;

            //    oEditColumn = (SAPbouiCOM.EditTextColumn)(oGrid.Columns.Item(1));
            //    oEditColumn.Editable = false;

            //    //oEditColumn = (SAPbouiCOM.EditTextColumn)(oGrid.Columns.Item(2));
            //    //oEditColumn.Editable = false;
            //}
            //else
            //{
            //    oEditColumn = (SAPbouiCOM.EditTextColumn)(oGrid.Columns.Item(0));
            //    oEditColumn.Editable = false;

            //    oEditColumn = (SAPbouiCOM.EditTextColumn)(oGrid.Columns.Item(1));
            //    oEditColumn.Editable = false;

            //    //oEditColumn = (SAPbouiCOM.EditTextColumn)(oGrid.Columns.Item(2));
            //    //oEditColumn.Editable = true;
            //}

            //for (int i = 0; i < oGrid.Rows.Count ; i++)
            //{
            //    oGrid.CommonSetting.MergeCell(i, 1, true);
            //}

            //oGrid.Columns.Item(2).Editable = true;
            //oGrid.Columns.Item(2).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            //oChkCol = (SAPbouiCOM.CheckBoxColumn)oGrid.Columns.Item(2);

            //oGrid.Columns.Item(4).Type = SAPbouiCOM.BoGridColumnType.gct_ComboBox;
            //oComCol = (SAPbouiCOM.ComboBoxColumn)(oGrid.Columns.Item(4));
            //oComCol.ValidValues.Add("0", "No Authorization");
            //oComCol.ValidValues.Add("1", "Full Authorization");              

        }

        private SAPbouiCOM.Grid Grid0;

        private void Button4_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Grid oGrid = null;               

                oForm = Application.SBO_Application.Forms.Item("NewForm1");
                oItem = oForm.Items.Item("Item_gsu");
                oGrid = (SAPbouiCOM.Grid)(oItem.Specific);

                oGrid.Rows.ExpandAll();                
                
            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void Grid0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.ColUID=="Authorization")
                {
                    oForm = Application.SBO_Application.Forms.Item("NewForm1");
                    oItem = oForm.Items.Item("Item_ok");

                    SAPbouiCOM.Button oButton = (SAPbouiCOM.Button)(oItem.Specific);
                    oButton.Caption = "Update";

                    oItem = oForm.Items.Item("item_lu");
                    oMatrix_User = (SAPbouiCOM.Matrix)(oItem.Specific);
                    oColumn = (SAPbouiCOM.Column)(oMatrix_User.Columns.Item(0));
                    oColumn.Editable = false;

                    //oItem.Visible = true;
                    oForm.Refresh();
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }

        }
    }
}