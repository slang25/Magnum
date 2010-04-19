﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<TestEchoViewModel>" %>

<%@ Import Namespace="Sample.WebActors"%>
<%@ Import Namespace="Sample.WebActors.Actors.Echo"%>
<%@ Import Namespace="Sample.WebActors.Actors.Query"%>
<%@ Import Namespace="Sample.WebActors.Controllers.TestEcho" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Echo Test Form</title>

	<script language="javascript" type="text/javascript" src="<%=Url.Content("~/Scripts/jquery-1.4.1.js")%>"></script>
	<script language="javascript" type="text/javascript" src="<%=Url.Content("~/Scripts/json2.js") %>"></script>

</head>
<body>
	<div>
		<% using (Html.BeginForm())
		 { %>
		<label for="Text">
			Enter a string to echo:</label>
		<%= Html.TextBoxFor(x => x.Text) %>
		<br />
		<textarea style="display: none" id="response" name="response" rows="10" cols="80"></textarea>
		<br />
		<input type="button" id="Send" name="Send" value="Send" />
		<div>Submission Url: <%= Url.Actor<EchoActor>(x => x.EchoChannel) %></div>
		<div>Other Submission Url: <%= Url.Actor<QueryActor>(x => x.GetCityChannel) %></div>
		<div id="status">
		</div>
		<% } %>
	</div>

	<script type="text/javascript" charset="utf-8">

		function submitForm() {
			var message = { "Text": $('#Text').val() };

			var json = JSON.stringify(message);

			$('#status').html("Sending...").show();
			$.ajax({
				url: '<%= Url.Content("~/Actors/Echo/Echo")%>',
				type: "POST",
				dataType: 'json',
				data: json,
				contentType: "application/json; charset=utf-8",
				success: function(json) {
					$('#response').html(json.Text).show();
					$('#status').html('');
				},
				error: function() {
					$('#status').html("Epic Fail: " + textStatus).show();
				}
			});
		}

		$(document).ready(function() {

			$("form").submit(function() {
				submitForm();
				return false;
			});

			$('#Send').click(function() {
				submitForm();
			});
		});	
	</script>

</body>
</html>
