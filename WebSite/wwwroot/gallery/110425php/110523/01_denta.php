<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>Hello World</title>
</head>
<body>
	<center><font color="red" size="5">でんた君</font></center>
	<hr />
	[超簡易電卓]
	<hr />
	<p>二つの数値を入力してください</p>
	<form method="post" action="<?php echo $_SERVER["PHP_SELF"]; ?>">
		<?php
			function calc_sbmt($valA, $valB, $opr){
				$res = "";
				switch($opr){
					case "+":
						$res = $valA + $valB;
						break;
					case "-":
						$res = $valA - $valB;
						break;
					case "*":
						$res = $valA * $valB;
						break;
					case "/":
						$res = $valA / $valB;
						break;
					default:
						$res = "";
				}
				return $res;
			}
		?>
		<p>
			<b>入力1</b>
			<input type="text" name="inA" size="10" />
			<b>入力2</b>
			<input type="text" name="inB" size="10" />
			<br />
			<br />

			<input type="submit" name="post_mode" value="+" />
			<input type="submit" name="post_mode" value="-" />
			<input type="submit" name="post_mode" value="*" />
			<input type="submit" name="post_mode" value="/" />
			&nbsp;&nbsp;&nbsp;&nbsp;

			<input type="reset" value="C" />
		</p>
	</form>
	<p>
	結果=
		<?php
			$opr = $_POST["post_mode"];
			$valA = $_POST["inA"];
			$valB = $_POST["inB"];

			echo calc_sbmt($valA, $valB, $opr);
		?>
	</p>
</body>
</html>