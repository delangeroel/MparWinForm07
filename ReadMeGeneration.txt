table 
name

table fields
Table, Fieldname

Fieldname
fieldname, description, type, length, decimals, order, required, autonum, format, displayField


tableRelations
table table, relationship[]

relationship
OneToMany, OneToOne, ManyToMany, ManyToOne, None
DependentEntity, PrincipalEntity, Principal Key, ForeignKey, NavigationProperty: Collection, References, Inverse, SelfReferencing



DisplayField[]
Label, TextField, ComboBox, List, CheckBox, DateTimePicker, 

typeEnum
TypeEnumValues

Type[] string, decimal, int, DateTime,  

table index name
table index name fields

table view name, isView, isQuery, 
table view fields: fields, order

Display
DisplayType[Selection, ListScreen, EditScreen, Prompt,ParentChild], Table


DisplayFields
Display, Format, Field, order, required, format, displayField

Format: header, scroll, scrollSelection, Edit, 

generateClass
- readTable
- generateClass
- generateField

generateController
-IList;
-AddNew();
-LoadView();
-Remove();
-Save();
-SelectedChanged(string actionKey);
-UpdateViewDetailValues(ActionCode action);
-UpdateWithViewValues(ActionCode action);

generateContext

generateView
-FieldsGetterSetter
-class
-Constructor
-fieldGetSet
-CanModify
-AddButton
-DeleteButton
-SaveButton
-SetController
-ClearGrid
-AddGrid
-UpdateGrid
-RemoveFromGrid
-GetIdOfSelectedGrid
-ListViewSelectionChanged
-FirstButton
-PreviousButton
-NextButton
-LastButton
-RefresPagingInfo
-CreateButton
-enums

generateModel
-class
-FieldsGetterSetter
-SaveRecord
-DeleteRecord
-getAllRecords
-getKeyRecord
-getAllRecordsPaged
-getAllRecordsCount

generateService
-class
-save
-delete
-getAllActionCodes
-getC 
-
generateView
-class
-addFields
-addPaging
-addListView
-addAddButton
-addDeleteButton
-addSaveButton
generateService    save,delete, 
