//  SAP MANAGE UI API 2007 SDK Sample
//****************************************************************************
//
//  File:      OrderFormManipulation.cs
//
//  Copyright (c) SAP MANAGE
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
//****************************************************************************

//**************************************************************************************************
// BEFORE STARTING:
// 1. Add reference to the "SAP Business One UI API"
// 2. Insert the development connection string to the "Command Line Argument"
//-----------------------------------------------------------------
// 1.
//    a. Project->References
//    b. check the "SAP Business One UI API" check box
//
// 2.
//     a. Project->Properties
//     b. choose 'Make' tab folder
//     c. place the following connection string in the 'Command Line Arguments' field
// 0030002C0030002C00530041005000420044005F00440061007400650076002C0050004C006F006D0056004900490056
//
//**************************************************************************************************

using Microsoft.VisualBasic;
using System;
namespace SysForm {
    public class SystemForm  { 
        //*****************************************************************
        // At the begining of every UI API project we should first
        // establish connection with a running SBO application.
        // *******************************************************************
        
        private SAPbouiCOM.Application SBO_Application; 
        
        private SAPbouiCOM.Form oOrderForm; 
        
        private SAPbouiCOM.Item oNewItem; 
        
        private SAPbouiCOM.Item oItem; 
        
        private SAPbouiCOM.Folder oFolderItem; 
        
        private SAPbouiCOM.OptionBtn oOptionBtn; 
        
        private SAPbouiCOM.CheckBox oCheckBox; 
        
        private int i; // to be used as a counter
        
        
        private void SetApplication() { 
            
            // *******************************************************************
            // Use an SboGuiApi object to establish the connection
            // with the application and return an initialized appliction object
            // *******************************************************************
            
            SAPbouiCOM.SboGuiApi SboGuiApi = null; 
            string sConnectionString = null; 
            
            SboGuiApi = new SAPbouiCOM.SboGuiApi(); 
            
            // by following the steps specified above, the following
            // statment should be suficient for either development or run mode
            
            sConnectionString = Interaction.Command(); 
            
            // connect to a running SBO Application
            
            SboGuiApi.Connect( sConnectionString ); 
            
            // get an initialized application object
            
            SBO_Application = SboGuiApi.GetApplication( -1 ); 
            
        } 
        
        
        private void AddItemsToOrderForm() { 
            
            // add a user data source
            // bear in mind that every item must be connected to a data source
            
            oOrderForm.DataSources.UserDataSources.Add( "OpBtnDS", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 1 ); 
            oOrderForm.DataSources.UserDataSources.Add( "CheckDS1", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 1 ); 
            oOrderForm.DataSources.UserDataSources.Add( "CheckDS2", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 1 ); 
            oOrderForm.DataSources.UserDataSources.Add( "CheckDS3", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 1 ); 
            
            
            //*****************************************
            // Adding Items to the Order form
            // and setting their properties
            //*****************************************
            
            
            //***************************
            // Adding Check Box items
            //***************************
            
            // use an existing item to place youe item on the form
            oItem = oOrderForm.Items.Item( "126" ); 
            
            for ( i=1; i<=3; i++ ) { 
                
                oNewItem = oOrderForm.Items.Add( "CheckBox" + i, SAPbouiCOM.BoFormItemTypes.it_CHECK_BOX ); 
                oNewItem.Left = oItem.Left; 
                oNewItem.Width = 100; 
                oNewItem.Top = oItem.Top + ( i - 1 ) * 19; 
                oNewItem.Height = 19; 
                
                // set the Item's Pane Level.
                // this value will determine the Items visibility
                // according to the Form's pane level
                oNewItem.FromPane = 5; 
                oNewItem.ToPane = 5; 
                
                oCheckBox = ( ( SAPbouiCOM.CheckBox )( oNewItem.Specific ) ); 
                
                // set the caption
                oCheckBox.Caption = "Check Box" + i; 
                
                // binding the Check box with a data source
                oCheckBox.DataBind.SetBound( true, "", "CheckDS" + i ); 
                
            } 
            
            //****************************
            // Adding Option button items
            //****************************
            
            // use an existing item to place youe item on the form
            oItem = oOrderForm.Items.Item( "44" ); 
            
            for ( i=1; i<=3; i++ ) { 
                
                oNewItem = oOrderForm.Items.Add( "OpBtn" + i, SAPbouiCOM.BoFormItemTypes.it_OPTION_BUTTON ); 
                oNewItem.Left = oItem.Left; 
                oNewItem.Width = 100; 
                oNewItem.Top = oItem.Top + ( i - 1 ) * 19; 
                oNewItem.Height = 19; 
                
                
                // set the Item's Pane Level.
                // this value will determine the Items visibility
                // according to the Form's pane level
                oNewItem.FromPane = 5; 
                oNewItem.ToPane = 5; 
                
                oOptionBtn = ( ( SAPbouiCOM.OptionBtn )( oNewItem.Specific ) ); 
                
                // set the caption
                oOptionBtn.Caption = "Option Button" + i; 
                
                if ( i > 1 ) { 
                    oOptionBtn.GroupWith( "OpBtn" + ((int)(i - 1)).ToString()); 
                } 
                
                oOptionBtn.DataBind.SetBound( true, "", "OpBtnDS" );    
            }
        } 
        
        public SystemForm() { 
            
            
            //*************************************************************
            // set SBO_Application with an initialized application object
            //*************************************************************
            
            SetApplication(); 
            
            //*************************************************************
            // send an "hello world" message
            //*************************************************************
            
            // SBO_Application.MessageBox("Hello World")
            
            // events handled by SBO_Application_ItemEvent
            
            SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler( SBO_Application_ItemEvent ); 
        } 
        
        private void SBO_Application_ItemEvent( string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent ) {
 
            BubbleEvent = true;
            
            if ( ( ( pVal.FormType == 139 & pVal.EventType != SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD ) & ( pVal.Before_Action == true ) ) ) { 
                
                // get the event sending form
                oOrderForm = SBO_Application.Forms.GetFormByTypeAndCount( pVal.FormType, pVal.FormTypeCount ); 
                
                if ( ( ( pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_LOAD ) & ( pVal.Before_Action == true ) ) ) { 
                    
                    // add a new folder item to the form
                    oNewItem = oOrderForm.Items.Add( "UserFolder", SAPbouiCOM.BoFormItemTypes.it_FOLDER ); 
                    
                    // use an existing folder item for grouping and setting the
                    // items properties (such as location properties)
                    // use the 'Display Debug Information' option (under 'Tools')
                    // in the application to acquire the UID of the desired folder
                    oItem = oOrderForm.Items.Item( "138" ); 
                    
                    
                    oNewItem.Top = oItem.Top; 
                    oNewItem.Height = oItem.Height; 
                    oNewItem.Width = oItem.Width; 
                    oNewItem.Left = oItem.Left + oItem.Width; 
                    
                    oFolderItem = ( ( SAPbouiCOM.Folder )( oNewItem.Specific ) ); 
                    
                    oFolderItem.Caption = "User Folder"; 
                    
                    // group the folder with the desired folder item
                    oFolderItem.GroupWith( "138" ); 
                    
                    // add your own items to the form
                    AddItemsToOrderForm(); 
                    
                    oOrderForm.PaneLevel = 1; 
                    
                } 
                
                // If pVal.EventType = SAPbouiCOM.BoEventTypes.et_CLICK And pVal.Before_Action = True Then
                // oOrderForm.PaneLevel = 5
                
                // End If
                if ( pVal.ItemUID == "UserFolder" & pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED & pVal.Before_Action == true ) { 
                    
                    // when the new folder is clicked change the form's pane level
                    // by doing so your items will apear on the new folder
                    // assuming they were placed correctly and their pane level
                    // was also set accordingly
                    oOrderForm.PaneLevel = 5; 
                    
                } 
                
            } 
        } 
        
        
        private void SBO_Application_AppEvent( SAPbouiCOM.BoAppEventTypes EventType ) { 
            
            switch ( EventType ) {
                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    
                    // Take care of terminating your AddOn application
                    
                    SBO_Application.MessageBox( "A Shut Down Event has been caught" + Constants.vbNewLine + "Terminating 'Order Form Manipulation' Add On...", 1, "Ok", "", "" ); 
                    
                    System.Environment.Exit( 0 ); 
                    
                    break;
            }  
        }    
    }    
} 
