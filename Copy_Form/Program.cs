using System;
using System.Collections.Generic;
using SAPbouiCOM.Framework;

namespace Copy_Form
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application oApp = null;
                if (args.Length < 1)
                {
                    oApp = new Application();
                }
                else
                {
                    //If you want to use an add-on identifier for the development license, you can specify an add-on identifier string as the second parameter.
                    //oApp = new Application(args[0], "XXXXX");
                    oApp = new Application(args[0]);
                }
                Menu MyMenu = new Menu();
                MyMenu.AddMenuItems();
                oApp.RegisterMenuEventHandler(MyMenu.SBO_Application_MenuEvent);
                Application.SBO_Application.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler(SBO_Application_AppEvent);
                Application.SBO_Application.ItemEvent += SBO_Application_ItemEvent;
                oApp.Run();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        public static SAPbouiCOM.Form oForm;
        public static SAPbouiCOM.Item oItem;
        public static SAPbouiCOM.Item oNewItem;
        private static void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            //throw new NotImplementedException();
            BubbleEvent = true;
            if ((pVal.FormType==140 && pVal.EventType != SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD)&& pVal.Before_Action==true)
            {
                oForm = Application.SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType,pVal.FormTypeCount);
                if (pVal.EventType==SAPbouiCOM.BoEventTypes.et_FORM_LOAD && pVal.Before_Action==true)
                {
                    SAPbouiCOM.ChooseFromListCollection oCFLs=null;
                    SAPbouiCOM.Conditions oCons = null;
                    SAPbouiCOM.Condition oCon = null;
                    oCFLs = oForm.ChooseFromLists;
                    SAPbouiCOM.ChooseFromList oCFL = null;
                    SAPbouiCOM.ChooseFromListCreationParams oCFLCreationParams = ((SAPbouiCOM.ChooseFromListCreationParams)(Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams)));
                    oCFLCreationParams.MultiSelection = false;
                    oCFLCreationParams.ObjectType = "17";
                    oCFLCreationParams.UniqueID = "CFL_2";
                    oCFL = oCFLs.Add(oCFLCreationParams);
                    oCons = oCFL.GetConditions();
                    oCon = oCons.Add();
                    oCon.Alias = "DocStatus";
                    oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon.CondVal = "O";
                    oCFL.SetConditions(oCons);
                    oCFLCreationParams.UniqueID = "CFL2";
                    oCFL = oCFLs.Add(oCFLCreationParams);

                    SAPbouiCOM.Button oButton = null;
                    oNewItem = oForm.Items.Item("2");
                    oItem = oForm.Items.Add("btnCopy", SAPbouiCOM.BoFormItemTypes.it_BUTTON);
                    oItem.Top = oNewItem.Top;
                    oItem.Height = oNewItem.Height;
                    oItem.Left = oNewItem.Left + oNewItem.Width + 5;
                    oItem.Width = oNewItem.Width + 20;
                    oButton = (SAPbouiCOM.Button)oItem.Specific;
                    oButton.Caption = "Coppy Form";
                    oButton.ChooseFromListUID = "CFL_2";

                    oButton.ChooseFromListAfter += OButton_ChooseFromListAfter;
                    
                }
            }

        }

        private static void OButton_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new NotImplementedException();
            //Application.SBO_Application.MessageBox("Business: "+oForm.);
        }

        static void SBO_Application_AppEvent(SAPbouiCOM.BoAppEventTypes EventType)
        {
            switch (EventType)
            {
                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    //Exit Add-On
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_CompanyChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_FontChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_LanguageChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ServerTerminition:
                    break;
                default:
                    break;
            }
        }
    }
}
