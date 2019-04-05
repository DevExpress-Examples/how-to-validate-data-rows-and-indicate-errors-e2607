<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/ValidatingDataRows/MainPage.xaml) (VB: [MainPage.xaml](./VB/ValidatingDataRows/MainPage.xaml))
* [MainPage.xaml.cs](./CS/ValidatingDataRows/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/ValidatingDataRows/MainPage.xaml.vb))
<!-- default file list end -->
# How to Validate Data Rows and Indicate Errors


<p>This example shows how to check the validity of data entered by end-users into a data row. The <i>ValidateRow</i> and <i>InvalidRowException</i> events are handled to validate the focused row's data. If its data is invalid, the row focus cannot be moved to another row until invalid values are corrected.<br />
Since the <strong>Task</strong> class doesn't support error notifications, it implements the <strong>IDXDataErrorInfo</strong> interface providing two members to get error descriptions for the entire row and for individual cells (data source fields). This displays error icons within cells with invalid values. Pointing to such an error icon displays a tooltip with an error description.<br />
 </p>

<br/>


