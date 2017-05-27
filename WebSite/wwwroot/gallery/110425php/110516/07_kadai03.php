<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>課題3</title>
</head>
<body>
	<?php
		$testDt = 12;
		$ensyu = $testDt * 2 * 3.14;
		$mensk = 3.14 * pow($testDt, 2);
		$taisk = (4/3) * 3.14 * pow($testDt, 3);
	?>
	<p>半径<?php echo $testDt; ?>の円周: <?php echo $ensyu; ?></p>
	<p>半径<?php echo $testDt; ?>の面積: <?php echo $mensk; ?></p>
	<p>半径<?php echo $testDt; ?>の堆積: <?php echo $taisk; ?></p>
	<p>1から100までの奇数値の合計は<?php echo $kisu; ?></p>
</body>
</html>