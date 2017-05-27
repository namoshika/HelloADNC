<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>簡易アンケート v00</title>
</head>
<body>
	<form method="post" action="02_questionnaire_confirm.php">
		お名前を入力してください<br />
		<input type="text" name="namae" /><br /><br />
		あなたの性別<br />
		<input type="radio" name="gender" value="male" checked="checked" />男性<br />
		<input type="radio" name="gender" value="famale" />女性<br /><br />
		あなたの好きな果実をいくつでも選んでください<br />
		<input type="checkbox" name="orange[]" value="いちご" />いちご<br />
		<input type="checkbox" name="orange[]" value="みかん" />みかん<br />
		<input type="checkbox" name="orange[]" value="すいか" />すいか<br />
		<input type="checkbox" name="orange[]" value="メロン" />メロン<br />
		<input type="checkbox" name="orange[]" value="バナナ" />バナナ<br /><br />
		あなたの趣味をいくつでも選んでください<br />
		<input type="checkbox" name="hobby[]" value="映画" />映画<br />
		<input type="checkbox" name="hobby[]" value="音楽" />音楽<br />
		<input type="checkbox" name="hobby[]" value="読書" />読書<br />
		<input type="checkbox" name="hobby[]" value="スポーツ" />スポーツ<br /><br />
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