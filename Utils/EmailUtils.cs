using App.Models;

namespace App.Utils;
public static class EmailUtils
{
    private static readonly string HOME_PAGE_LINK = "<a style='color: #f80;text-decoration: none;' href='https://localhost:3000'>RaoVat.net</a>";

    public static (string, string) GenerateRejectMail(Ad ad)
    {
        var subject = $"Tin đăng #{ad.Id} đã bị từ chối";
        var body = @$"
            <div style='
                padding: 30px;
                width: 100%;
                background-color: #e8e8e8;
            '>
        <div style='width: 450px; 
                    margin: 0 auto;
                    background-color: #fff;
                    border: 1px solid grey;
                    padding: 16px;'>
            <div
                style='display: flex; align-items: center; justify-content: center; font-size: 26px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;'>
                <img src='https://raw.githubusercontent.com/TranQuyenSinh/Image-store/main/logo_2.png'
                    width='100%' height='120' />
            </div>
            <div
                style='font-size: 18px; line-height: 30px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; letter-spacing: -1px;'>
                <p>
                    Xin chào <b>{ad.Author?.FullName}</b>,</br>
                    Tin đăng <b><a style='text-decoration: none;'
                            href='https://localhost:3000/tin-dang/{ad.Id}'>#{ad.Id}</a></b> của bạn đã bị từ chối.
                </p>
                <hr>
                <table style='width: 100%;'>
                    <tbody>
                        <tr>
                            <th style='text-align: start;'>Tiêu đề:</th>
                            <td>{ad.Title}</td>
                        </tr>
                        <tr>
                            <th style='text-align: start'>Giá rao:</th>
                            <td>{ad.Price:n0} đ</td>
                        </tr>
                        <tr>
                            <th style='text-align: start'>Lý do từ chối:</th>
                            <td><b>{ad.RejectReason}</b></td>
                        </tr>
                        <tr>
                            <th style='text-align: start'>Duyệt lúc:</th>
                            <td>{ad.AprovedAt.Value:dd/MM/yyyy HH:mm:ss}</td>
                        </tr>
                    </tbody>
                </table>
                <hr>
                <p>
                    Hãy đăng nhập {HOME_PAGE_LINK} và
                    theo dõi trạng thái tin
                    đăng của mình.
                    Nếu bạn có bất kỳ thắc mắc nào, vui lòng liên hệ với
                    <a style='color: #f80;text-decoration: none;' href='https://localhost:3000'>đội ngũ hỗ trợ</a> để
                    được trợ giúp.
                </p>
                <p>Chúc bạn luôn có những trải nghiệm tuyệt vời khi sử dụng dịch vụ tại RaoVat.net</p>
                <p>Trân trọng, </br>Đội ngũ RaoVat.net</p>
            </div>
        </div>
    </div>
            ";
        return (subject, body);
    }

    public static (string, string) GenerateApprovedMail(Ad ad)
    {
        var subject = $"Tin đăng #{ad.Id} đã được duyệt thành công";
        var body = @$"
            <div style='
                padding: 30px;
                width: 100%;
                background-color: #e8e8e8;
            '>
        <div style='width: 450px; 
                    margin: 0 auto;
                    background-color: #fff;
                    border: 1px solid grey;
                    padding: 16px;'>
            <div
                style='display: flex; align-items: center; justify-content: center; font-size: 26px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;'>
                <img src='https://raw.githubusercontent.com/TranQuyenSinh/Image-store/main/logo_2.png'
                    width='100%' height='120' />
            </div>
            <div
                style='font-size: 18px; line-height: 30px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; letter-spacing: -1px;'>
                <p>
                    Xin chào <b>{ad.Author?.FullName}</b>,</br>
                    Tin đăng <b><a style='text-decoration: none;'
                            href='https://localhost:3000/tin-dang/{ad.Id}'>#{ad.Id}</a></b> của bạn đã được duyệt thành
                    công.
                </p>
                <hr>
                <table style='width: 100%;'>
                    <tbody>
                        <tr>
                            <th style='text-align: start;'>Tiêu đề:</th>
                            <td>{ad.Title}</td>
                        </tr>
                        <tr>
                            <th style='text-align: start'>Giá rao:</th>
                            <td>{ad.Price:n0} đ</td>
                        </tr>
                        <tr>
                            <th style='text-align: start'>Duyệt lúc:</th>
                            <td>{ad.AprovedAt.Value:dd/MM/yyyy HH:mm:ss}</td>
                        </tr>
                    </tbody>
                </table>
                <hr>
                <p>
                    Hãy đăng nhập {HOME_PAGE_LINK} và
                    theo dõi trạng thái tin
                    đăng của mình.
                    Nếu bạn có bất kỳ thắc mắc nào, vui lòng liên hệ với
                    <a style='color: #f80;text-decoration: none;' href='https://localhost:3000'>đội ngũ hỗ trợ</a> để
                    được trợ giúp.
                </p>
                <p>Chúc bạn luôn có những trải nghiệm tuyệt vời khi sử dụng dịch vụ tại RaoVat.net</p>
                <p>Trân trọng, </br>Đội ngũ RaoVat.net</p>
            </div>
        </div>
    </div>
            ";
        return (subject, body);
    }
}