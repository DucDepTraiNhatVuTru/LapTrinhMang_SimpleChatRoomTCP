# LapTrinhMang_SimpleChatRoomTCP

Đang say nên có thể nhiều chổ nó hơi như "bull shit", nhưng mà nó chạy được nhé!

Chương trình demo đơn giản trên console.
Tính năng chỉ là client có thể gửi tin nhắn nhiều lần và nhận tin nhắn nhiều lần.
Không bắt các lỗi ngoài tính năng.


Server:
- Khi Client Connect đến, thì lưu client lại trong 1 danh sách.
- Client gửi tin nhắn lên server thì server gửi lại cho toàn bộ các client khác nội dung vừa đến (Thread).


Client:
gồm 2 tiểu trình:
- Nhận
- Gửi
