<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>ごうけい君v0.0</title>
</head>
<body>
	<center><font color="red" size="5">ごうけい君</font></center>
	<hr />
	[超簡易電卓]
	<hr />
	<p>二つの数値を入力してください</p>
	<form method="post" action="<?php echo $_SERVER["PHP_SELF"]; ?>">
		<p>
			<b>入力1</b><input type="text" name="inA" size="10" />
			<b>入力2</b><input type="text" name="inB" size="10" />
			<b>入力3</b><input type="text" name="inC" size="10" />
			<br /><br />

			<input type="submit" name="post_mode" value="Calc" />&nbsp;&nbsp;&nbsp;&nbsp;
			<input type="reset" value="C" />

			<input type="hidden" name="inputed" value="true" />
		</p>
		<?php
			function calc_sum($valA, $valB, $valC){
				return $valA + $valB + $valC;
			}
			function calc_avg($valA, $valB, $valC){
				return calc_sum($valA, $valB, $valC) / 3;
			}
			function calc_max($valA, $valB, $valC){
				if($valA > $valB){
					return $valA;
				}else if($valB > $valC){
					return $valB;
				}else{
					return $valC;
				}
			}
			function calc_min($valA, $valB, $valC){
				if($valA < $valB){
					return $valA;
				}else if($valB < $valC){
					return $valB;
				}else{
					return $valC;
				}
			}

			$flg = $_POST["inputed"] == true;
			$valA = $_POST["inA"];
			$valB = $_POST["inB"];
			$valC = $_POST["inC"];
		?>
	</form>
	<?php
		if($flg){
	?>
	<p>
		合計=<?php echo calc_sum($valA, $valB, $valC); ?><br />
		平均=<?php echo calc_avg($valA, $valB, $valC); ?><br />
		最大値=<?php echo calc_max($valA, $valB, $valC); ?><br />
		最小値=<?php echo calc_min($valA, $valB, $valC); ?><br />
	</p>
	<?php
		}else{
			echo "3つの数値を入力してください。";
		}
	?>
</body>
</html>