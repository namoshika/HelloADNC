<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>課題２アンケート </title>
</head>
<body>
	<center><font color="blue" size="5">簡易アンケート v.1.0</font></center>
	<form method="post" action="02_questionnaire_confirm.php">
		お名前を入力してください<br />
		<input type="text" name="namae" /><br /><br />
		あなたの性別<br />
		<input type="radio" name="gender" value="0" checked="checked" />男性<br />
		<input type="radio" name="gender" value="1" />女性<br /><br />
		あなたの好きな果実をいくつでも選んでください<br />
		<input type="checkbox" name="strawberry" value="1" />いちご<br />
		<input type="checkbox" name="orange" value="1" />みかん<br />
		<input type="checkbox" name="watermelon" value="1" />すいか<br />
		<input type="checkbox" name="melon" value="1" />メロン<br />
		<input type="checkbox" name="banana" value="1" />バナナ<br /><br />
		あなたの趣味をいくつでも選んでください<br />
		<input type="checkbox" name="hobby[0]" value="1" />映画<br />
		<input type="checkbox" name="hobby[1]" value="1" />音楽<br />
		<input type="checkbox" name="hobby[2]" value="1" />読書<br />
		<input type="checkbox" name="hobby[3]" value="1" />スポーツ<br /><br />
		あなたの出身の地域を選んでください<br />
		<select name="region">
			<option value="0" selected="selected">北海道</option>
			<option value="1" >東京</option>
			<option value="2">京都</option>
		</select>
		<br /><br />
		ご意見をお書きください<br />
		<textarea name="comment" rows="5" cols="30">PHPは楽しい!!</textarea><br />
		<input type="submit" name="button1" value="送信" />
		<input type="reset" />
	</form>
</body>
</html>