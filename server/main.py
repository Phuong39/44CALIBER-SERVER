from flask import Flask, render_template, request, jsonify
from werkzeug.utils import secure_filename
from telebot import TeleBot
 
TOKEN = ""
userid = 1234
tb = TeleBot(token=TOKEN)
app = Flask(__name__)
 
delete_file_from_db_after_upload = False # если True, лог удаляется с сервера после отправки в тг
 
@app.route("/", methods=["GET", "POST"])
def upload_file():
    if request.method == "POST":
        message = request.args.get("message")
        print(request.files)
        ft = request.files.get("file")
        if ft is None:
            return jsonify(error="your request has no files")
        filename = f"uploaded/{secure_filename(ft.filename)}"
        ft.save(filename)
 
        with open(filename, "rb") as f:
            tb.send_document(userid, f, timeout=10, caption=message)
            f.close()
 
        if delete_file_from_db_after_upload:
            os.remove(filename)
 
        return "1"
    else:
        return jsonify(error="POST request is required")

app.run(port=5264, debug=True)