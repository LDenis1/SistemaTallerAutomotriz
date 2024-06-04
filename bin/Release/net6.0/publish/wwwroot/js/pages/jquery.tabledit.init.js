/**
 * Theme: Dastone - Responsive Bootstrap 5 Admin Dashboard
 * Author: Mannatthemes
 * Tabledit Js
 */


 
$(function() {

  $('#makeEditable').SetEditable({ $addButton: $('#but_add')});

  $('#submit_data').on('click',function() {
  var td = TableToCSV('makeEditable', ',');
  console.log(td);
  var ar_lines = td.split("\n");
  var each_data_value = [];
  for(i=0;i<ar_lines.length;i++)
  {
      each_data_value[i] = ar_lines[i].split(",");
  }

  for(i=0;i<each_data_value.length;i++)
  {
      if(each_data_value[i]>1);
      

  }

});
});

$('#mainTable').editableTableWidget().numericInputExample().find('td:first').focus();

