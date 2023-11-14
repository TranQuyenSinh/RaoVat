import React, { useEffect } from 'react'

import { useDispatch } from 'react-redux'

import Section from '../../../components/customer/Section/Section'
import { checkUserIsLoggedIn } from '../../../redux/user/user.actions'
import FloatingInput from '../../../components/input/CustomInput/FloatingInput'
import FloatingTextArea from '../../../components/input/CustomInput/FloatingTextArea'
import './AccountSetting.scss'

const AccountSetting = () => {
    const dispatch = useDispatch()
    useEffect(() => {
        document.title = 'Rao vặt - Cài đặt tài khoản'
        dispatch(checkUserIsLoggedIn())
    }, [])

    return (
        <div className='settings-container'>
            <div className='sidebar'>
                <Section className='avatar-container m-0'>
                    <img
                        className='img-rounded avatar'
                        src='https://buffer.com/cdn-cgi/image/w=1000,fit=contain,q=90,f=auto/library/content/images/size/w1200/2023/10/free-images.jpg'
                        alt=''
                    />
                    <div className='fullname'>Trần Quyền Sinh</div>
                    <button className='btn btn-main mt-2'>Đổi ảnh đại diện</button>
                </Section>
                <Section className='menu m-0'>
                    <span className='sidebar-item sidebar-item--selected'>Thông tin cá nhân</span>
                    <span className='sidebar-item'>Đổi mật khẩu</span>
                </Section>
            </div>
            <Section className='content'>
                <div className='title'>Hồ sơ công khai</div>
                <div className='row mt-3'>
                    <div className='col-md-6'>
                        <FloatingInput label={'Họ và tên'} />
                    </div>
                    <div className='col-md-6'>
                        <FloatingInput label={'Số điện thoại'} />
                    </div>
                    <div className='col-md-12'>
                        <FloatingInput label={'Địa chỉ'} />
                    </div>
                    <div className='col-md-12'>
                        <FloatingTextArea
                            label={'Giới thiệu'}
                            placeHolder={'Vài dòng giới thiệu về gian hàng của bạn'}
                        />
                    </div>
                </div>

                <div className='title mt-3'>Hồ sơ cá nhân</div>
                <p className='note'>Chỉ bạn mới có thể thấy những thông tin này.</p>
                <div className='row'>
                    <div className='col-md-12'>
                        <FloatingInput label={'Email'} disabled value={'vn.quyensinh@gmail.com'} />
                    </div>
                    <div className='col-md-6'>
                        <FloatingInput label={'Giới tính'} />
                    </div>
                    <div className='col-md-6'>
                        <FloatingInput label={'Ngày sinh'} />
                    </div>
                </div>
                <button className='btn btn-main mt-2'>Lưu thay đổi</button>
            </Section>
        </div>
    )
}

export default AccountSetting
