# Trả lời câu hỏi thiết kế
## 1. Factory đang che giấu quyết định thiết kế nào?
Factory che giấu logic phân loại chuỗi đầu vào để khởi tạo đối tượng thiết bị phù hợp trong hệ thống.
## 2. Singleton bảo đảm điều gì, nhưng tạo ra rủi ro nào?
- Bảo đảm: Chỉ có duy nhất một thể hiện của HomeConfiguration tồn tại và được chia sẻ toàn cục trong suốt vòng đời ứng dụng.   
- Rủi ro: Làm các bài unit test khó chạy độc lập vì thay đổi cấu hình ở test này có thể ảnh hưởng sang test khác.
## 3. Facade khác Factory ở mục đích chính như thế nào?
- Facade thuộc nhóm cấu trúc: cung cấp 1 giao diện thao tác cấp cao, đơn giản hóa việc gọi hàm (gọi 1 hàm gọi các hàm khác thay vì gọi thủ công từng hàm).
- Factory thuộc nhóm khởi tạo: tập trung vào việc đóng gói và tách rời quy trình tạo ra đối tượng khỏi client.
## 4. Nếu bỏ SmartHomeFacade, client sẽ phải biết thêm những chi tiết nào?
Client sẽ phải tự biết danh sách đầy đủ các thiết bị tham gia vào từng chế độ, tự ghi nhớ đúng trình tự bật/tắt/khóa từng thiết bị cho mỗi kịch bản, và phải tự truy xuất cấu hình HomeConfiguration.Instance.NightLightLevel để xử lý mức sáng ban đêm.   
