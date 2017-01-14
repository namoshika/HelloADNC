<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>フォームのデータを受け取る</title>
</head>
<body>
	<form method="post" action="<?php echo $_SERVER["PHP_SELF"]; ?>">
		<p>氏名を入力してください</p>
		<input type="text" name="yourname" /><br /><br />
		<p>性別</p>
		<input type="radio" name="gender" value="man" checked="checked" />男
		<input type="radio" name="gender" value="woman" />女
		<p>好きな食べ物</p>
		<input type="checkbox" name="favfood[]" value="和食" />和食
		<input type="checkbox" name="favfood[]" value="中華" />中華
		<input type="checkbox" name="favfood[]" value="洋食" />洋食
		<p>好きなスポーツ</p>
		<select name="favsports">
			<option value="野球" selected="selected">野球</option>
			<option value="テニス">テニス</option>
			<option value="サッカー">サッカー</option>
			<option value="柔道">柔道</option>
			<option value="剣道">剣道</option>
		</select>
		<br /><br />

		<textarea name="foo" rows="5" cols="30">ご自由に入力してください</textarea>
		<input type="submit" name="送信" value="送信" /><br />
		<input type="reset" /><br />
	</form>

	<?php
		//エラーチェック
		if($_POST["yourname"] == null){
			echo "error";
			exit;
		}
	?>
	<p>氏名:&nbsp;<?php echo $_POST["yourname"]; ?></p>
	<p>性別:&nbsp;<?php echo $_POST["gender"] == "man" ? "男" : "女"; ?></p>
	<p>好きな食べ物</p>
	<ul>
		<?php
			for($i = 0; $i < count($_POST["favfood"]); $i++){
				echo "<li>".$_POST["favfood"][$i]."</li>";
			}
		?>
	</ul>
	<p>好きなスポーツ:&nbsp;<?php echo $_POST["favsports"] ?></p>
	<p>一言<br /><?php echo $_POST["foo"] ?></p>
</body>
</html>