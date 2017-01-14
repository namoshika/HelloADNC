<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=100">
	<title>商品注文画面 v00</title>
	<style type="text/css">
		h1{
			font-size: 1.3em;
			text-align: center;
			margin: 0px;
		}
		.orderparam{
			margin: 1em 0em;
		}
		.orderparam > h2{
			font-size: 1em;
			font-weight: normal;
			margin: 0px;
		}
		.orderparam > p{
			margin: 0px;
		}
		.listup{
			margin: 0px;
			padding: 0px;
		}
		.listup > li{
			list-style: none;
		}
		.hori > li{
			float: left;
		}
		.hori:after {
			content: "";
			clear: both;
			width: 0px;
			display: block;
			visibility: hidden;
		}
	</style>
</head>
<body>
	<h1>商品注文画面</h1>
	<form method="post" action="04_order_confirm.php">
		<div class="orderparam">
			<h2>商品を選択してください</h2>
			<select name="item">
				<option value="0">PHP入門(1000円)</option>
				<option value="1">PHP入門の入門(1000円)</option>
				<option value="2">PHP入門の入門の入門(1000円)</option>
				<option value="3">PHP入門の入門の入門の入門(1000円)</option>
			</select>
		</div>
		<div class="orderparam">
			<h2>お名前</h2>
			<input type="text" name="namae" />
		</div>
		<div class="orderparam">
			<h2>送付先</h2>
			<input type="text" name="itemtarget" />
		</div>
		<div class="orderparam">
			<h2>配送の希望時間</h2>
			<ul class="listup hori">
				<li><input type="radio" name="hopetime" value="0">午前</li>
				<li><input type="radio" name="hopetime" value="1">午後</li>
				<li><input type="radio" name="hopetime" value="2">夜間</li>
			</ul>
		</div>
		<div class="orderparam">
			<h2>オプション</h2>
			<ul class="listup">
				<li><input type="checkbox" name="options[]" value="forpresent">贈り物用包装希望</li>
			</ul>
		</div>
		<div class="orderparam">
			<h2>他に希望があればお書きください</h2>
			<textarea name="comment" rows="5" cols="30">佐川急便はやめろ</textarea><br />
		</div>
		<input type="submit" name="button1" value="送信" />
		<input type="reset" />
	</form>
</body>
</html>