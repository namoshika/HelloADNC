<div id="siteHeaderDiv">
	<script type="text/javascript">
	function logout(){
		document.forms.logoutFrm.submit();
	}
	</script>
	<h1 class="title">ToDo homeworks</h1>
	<ul class="menu">
		<?php
			if($_SESSION["userId"] !== null){
				echo "<li><a href=\"javascript:logout()\">Logout</a></li>";
			}
		?>
		<li><a href="profile.php">Account</a></li>
	</ul>
	<form name="logoutFrm" method="post" action="php/authenticate.php?req=logout">
		<input type="hidden" name="url" value="../">
	</form>
</div>