<?php session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="ja" lang="ja">
<head>
	<title>予定編集</title>
	<?php
	include 'common/php/dataClasses.php';
	include 'common/php/headerHeader.php';

	mysql_connect('db2.ne.senshu-u.ac.jp', 'webprog13', 'tokushu2011');
	mysql_select_db('webprog13');

	//科目リストを作成する
	$sbjctAry = array();
	$res = mysql_query("select B.id, B.name from tskmng_registsubject as A inner join tskmng_subject as B on A.subjectid = B.id where A.personid = {$_SESSION["userId"]}");
	while($row = mysql_fetch_array($res)){
		$sbjctAry[] = new SubjectInfo($row["id"], $row["name"]);
	}

	if(isset($_GET["taskid"])){
		//taskInfoをDBから探す。あったらインスタンス化。
		//なかったらタスクを新たに作る方向で

		$usrCode = $_SESSION["userId"];
		$tskCode = $_GET["taskid"];
		$res = mysql_query("select A.id as taskid, B.id as subjectid, B.name as subjectname, A.name as taskname, A.limitdate, A.priority, A.state, A.memo from tskmng_registtask as A inner join tskmng_subject as B on A.subjectid = B.id where A.personid = {$usrCode} && A.id = {$tskCode}");
		if(($row = mysql_fetch_array($res)) === false){
			$tskInfo = new TaskInfo(-1, -1, "科目名", "課題名を入力してください", date("Y/m/d"), TaskInfo::PRIORITY_NORMAL, TaskInfo::STATUS_NOT_YET, "");
			echo "loading TaskList Error.";
		}else{
			$tskInfo = new TaskInfo($row["taskid"], $row["subjectid"], $row["subjectname"], $row["taskname"], $row["limitdate"], $row["priority"], $row["state"], $row["memo"]);
		}
	}else{
		$tskInfo = new TaskInfo(-1, -1, "科目名", "課題名を入力してください", date("Y/m/d"), TaskInfo::PRIORITY_NORMAL, TaskInfo::STATUS_NOT_YET, "");
	}
	?>
	<script type="text/javascript">
	function taskEditFormSubmit(){
		document.forms.tskEdtFrm.submit();
	}
	function taskEditFormClear(){
		document.forms.tskEdtFrm.reset();
	}
	</script>
</head>
<body>
	<?php include 'common/php/bodyHeader.php'; ?>
	<div class="mainDiv">
		<div id="taskQuickEditDiv">
			<h2>操作</h2>
			<p>編集を取り消して...</p>
			<ul>
				<li><a href="./">課題リストへ戻る</a></li>
				<?php
				if($tskInfo->id >= 0){
					echo "<li><a href=\"./detail.php?taskid={$tskInfo->id}\">課題詳細へ戻る</a></li>";
				}
				?>

			</ul>
			<p>この課題を...</p>
			<ul>
				<li><a href="javascript:taskEditFormSubmit()">保存する</a></li>
				<li><a href="javascript:taskEditFormClear()">入力内容をクリアする</a></li>
			</ul>
		</div>
		<div id="taskEditDiv" >
			<h2><?php echo $tskInfo->id < 0 ? "課題を追加" : "課題を編集" ?></h2>
			<form name="tskEdtFrm" method="post" action="./php/taskEdit.php">
				<dl class="keyValDef">
					<dt class="key">科目:</dt>
					<dd class="val">
						<select name="subjectid">
							<?php
							foreach($sbjctAry as $info){
								$selectAttrbStr = $info->id === $tskInfo->subjectId ? "selected=\"selected\"" : "";
								echo "<option value=\"{$info->id}\" {$selectAttrbStr}>{$info->name}</option>\n";
							}
							?>
						</select>
					</dd>
					<dt class="key name">名前：</dt>
					<dd class="val"><input type="text" name="taskName" value="" /></dd>
					<dt class="key">期限:</dt>
					<dd class="val">
						<dl>
							<dt>手動入力</dt>
							<dd><input type="radio" name="limitDate" value="manual" checked="checked" /><input type="text" name="limitDateText" value="" /></dd>
							<dt>クイック入力</dt>
							<dd><input type="radio" name="limitDate" value="1week" />一週間後(<?php echo date("m/d", time() + 86400 * 7); ?>)</dd>
							<dd><input type="radio" name="limitDate" value="2week" />二週間後(<?php echo date("m/d", time() + 86400 * 14); ?>)</dd>
						</dl>
					</dd>
					<dt class="key">優先順位:</dt>
					<dd class="val"><input type="checkbox" name="priority" /></dd>
					<dt class="key">進行状況:</dt>
					<dd class="val">
						<select name="status">
							<option value="<?php echo TaskInfo::STATUS_NOT_YET; ?>" <?php echo $tskInfo->status == TaskInfo::STATUS_NOT_YET ? "selected=\"selected\"": ""; ?> >未着手</option>
							<option value="<?php echo TaskInfo::STATUS_FREEZE; ?>" <?php echo $tskInfo->status == TaskInfo::STATUS_FREEZE ? "selected=\"selected\"": ""; ?>>凍結</option>
							<option value="<?php echo TaskInfo::STATUS_FINISH; ?>" <?php echo $tskInfo->status == TaskInfo::STATUS_FINISH ? "selected=\"selected\"": ""; ?>>完了</option>
						</select>
					</dd>
					<dt class="key">メモ:</dt>
					<dd class="val">
						<textarea name="memo" rows="15" cols="50"></textarea>
					</dd>
				</dl>
				<input type="hidden" name="type" value="<?php echo $tskInfo->id < 0 ? "add" : "change" ?>" />
				<input type="hidden" name="taskid" value="<?php echo $tskInfo->id < 0 ? "" : $tskInfo->id; ?>" />
				<input type="hidden" name="url" value="../" />
			</form>
			<script type="text/javascript">
			document.forms.tskEdtFrm.taskName.value = "<?php echo $tskInfo->name; ?>";
			document.forms.tskEdtFrm.limitDateText.value = "<?php echo date("Y/m/d", $tskInfo->limitDate); ?>";
			document.forms.tskEdtFrm.taskName.value = "<?php echo $tskInfo->name; ?>";
			document.forms.tskEdtFrm.memo.value = "<?php echo $tskInfo->memo; ?>";
			document.forms.tskEdtFrm.priority.checked = <?php echo $tskInfo->priority == TaskInfo::PRIORITY_HIGH ? "true" : "false"; ?>;
			</script>
		</div>
	</div>
</body>
</html>
