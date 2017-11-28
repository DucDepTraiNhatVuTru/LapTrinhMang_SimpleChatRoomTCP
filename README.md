# LapTrinhMang_SimpleChatRoomTCP
Chương trình demo đơn giản trên console.
Tính năng chỉ là client có thể gửi tin nhắn nhiều lần và nhận tin nhắn nhiều lần.
Không bắt các lỗi ngoài tính năng.


Server:
- Khi Client Connect đến, thì lưu client lại trong 1 danh sách.
- Client gửi tin nhắn lên server thì server gửi lại cho toàn bộ các client khác nội dung (Thread).
Client:
gồm 2 tiểu trình:
- Nhận
- Gửi
