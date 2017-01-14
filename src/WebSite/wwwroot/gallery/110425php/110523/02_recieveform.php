<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>フォームのデータを受け取る</title>
</head>
<body>
	<form method="post" action="<?php echo $_SERVER["PHP_SELF"]; ?>">
		氏名を入力してください<br />
		<input type="text" name="yourname" /><br /><br />

		学びたい言語を入力してください<br />
		<input type="checkbox" name="checks[]" value="PHP" />PHP
		<input type="checkbox" name="checks[]" value="Perl" />Perl
		<input type="checkbox" name="checks[]" value="ASP" />ASP
		<input type="checkbox" name="checks[]" value="JSP"/>JSP
		<br />

		趣味を入力してください<br />
		<input type="text" name="textA" /><br />
		<input type="text" name="textB" /><br />
		<input type="text" name="textC" /><br />

		<input type="submit" name="送信" value="sub1" /><br />
	</form>

	<?php
		//エラーチェック
		if($_POST["yourname"] == null){
			echo "error";
			exit;
		}
	?>
	<p>名前:<br /><?php echo $_POST["yourname"]; ?></p>
	<p>言語:</p>
	<ul>
		<?php
			for($i = 0; $i < count($_POST["checks"]); $i++){
				echo "<li>".$_POST["checks"][$i]."</li>";
			}
		?>
	</ul>
	<p>
		趣味:<br />
		<?php
			echo $_POST["textA"]."<br />";
			echo $_POST["textB"]."<br />";
			echo $_POST["textC"]."<br />";
		?>
	</p>
</body>
</html>