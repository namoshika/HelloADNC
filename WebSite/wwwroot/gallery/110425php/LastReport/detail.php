<?php session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="ja" lang="ja">
<head>
	<title>課題詳細</title>
	<?php
	require 'common/php/dataClasses.php';
	require 'common/php/headerHeader.php';

	mysql_connect('db2.ne.senshu-u.ac.jp', 'webprog13', 'tokushu2011');
	mysql_select_db('webprog13');

	$usrCode = $_SESSION["userId"];
	$tskCode = $_GET["taskid"];
	$res = mysql_query("select A.id as taskid, B.id as subjectid, B.name as subjectname, A.name as taskname, A.limitdate, A.priority, A.state, A.memo from tskmng_registtask as A inner join tskmng_subject as B on A.subjectid = B.id where A.personid = {$usrCode} && A.id = {$tskCode} order by A.limitdate");
	if(($row = mysql_fetch_array($res)) === false){
		//Error
		$tskInfo = new TaskInfo(-1, -1, "error", "error", 0, -1, -1, null);
		echo "loading TaskList Error.";
	}else{
		$tskInfo = new TaskInfo($row["taskid"], $row["subjectid"], $row["subjectname"], $row["taskname"], $row["limitdate"], $row["priority"], $row["state"], $row["memo"]);
	}
	?>
	<script type="text/javascript">
	function changeStatusToFinish(){
		document.forms.chgFnshFrm.submit();
	}
	function deleteTask(){
		document.forms.delTskFrm.submit();
	}
	</script>
</head>
<body>
	<?php
	require 'common/php/bodyHeader.php';
	?>
	<div class="mainDiv">
		<div id="taskQuickEditDiv">
			<h2>操作</h2>
			<p>このページから...</p>
			<ul>
				<li><a href="./">課題リストへ戻る</a></li>
			</ul>
			<p>この課題を...</p>
			<ul>
				<li><a href="edit.php?taskid=<?php echo $tskInfo->id; ?>">編集する</a></li>
				<li><a href="javascript:changeStatusToFinish()">進行状況を完了にする</a></li>
				<li><a href="javascript:deleteTask()">削除する</a></li>
			</ul>
		</div>
		<div id="taskDetailDiv">
			<h2>課題詳細</h2>
			<dl class="keyValDef">
				<dt class="key name">名前：</dt>
				<dd class="val name"><?php echo $tskInfo->name ?></dd>
				<dt class="key name">科目：</dt>
				<dd class="val name"><?php echo $tskInfo->subjectName ?></dd>
				<dt class="key">期限:</dt>
				<dd class="val"><?php echo date("m/d(D)", $tskInfo->limitDate); ?></dd>
				<dt class="key">優先順位:</dt>
				<dd class="val">
				<?php
				switch ($tskInfo->priority){
					case TaskInfo::PRIORITY_NORMAL:
						echo "並";
						break;
					case TaskInfo::PRIORITY_HIGH:
						echo "高";
						break;
				}
				?>
				</dd>
				<dt class="key">進行状況:</dt>
				<dd class="val">
				<?php
				switch ($tskInfo->status){
					case TaskInfo::STATUS_NOT_YET:
						echo "未着手";
						break;
					case TaskInfo::STATUS_FREEZE:
						echo "凍結";
						break;
					case TaskInfo::STATUS_FINISH:
						echo "完了";
						break;
				}
				?>
				</dd>
				<dt class="key">メモ:</dt>
				<dd class="val"><p><?php echo $tskInfo->memo; ?></p></dd>
			</dl>
			<form method="post" name="chgFnshFrm" action="./php/taskEdit.php">
				<input type="hidden" name="type" value="status" />
				<input type="hidden" name="status" value="<?php echo TaskInfo::STATUS_FINISH; ?>" />
				<input type="hidden" name="taskid" value="<?php echo $tskInfo->id; ?>" />
				<input type="hidden" name="url" value="../" />
			</form>
			<form method="post" name="delTskFrm" action="./php/taskEdit.php">
				<input type="hidden" name="type" value="del" />
				<input type="hidden" name="taskid" value="<?php echo $tskInfo->id; ?>" />
				<input type="hidden" name="url" value="../" />
			</form>
		</div>
	</div>
</body>
</html>