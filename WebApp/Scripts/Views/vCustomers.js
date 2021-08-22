
function vCustomers() {

	this.tblCustomersId = 'tblCustomers';
	this.service = 'customer';
	this.ctrlActions = new ControlActions();
	this.columns = "Id,Name,LastName,Age";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblCustomersId, false); 		
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblCustomersId, true);
	}

	this.Create = function () {
		var seleccionEstCvl = document.getElementById('DDEstCiv').value;
		var seleccionGenero = document.getElementById('DDGenero').value;
		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		customerData.estadoCivil = seleccionEstCvl;
		customerData.genero = seleccionEstCvl;
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, banco_Data, function () {
			var v_Customer = vCustomers();
			//Refresca la tabla
			this.ctrlActions.GetDataForm('frmEdition');
			this.ReloadTable();
			document.getElementById('DDEstCiv').getElementsByTagName('option')[0].selected = 'seleccionado'
			document.getElementById('DDGenero').getElementsByTagName('option')[0].selected = 'seleccionado'
		});
	}

	this.Update = function () {																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																									

		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, customerData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, customerData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {	
	var vcustomer = new vCustomers();
	vcustomer.RetrieveAll();

});

