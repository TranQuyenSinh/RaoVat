import React, { useState } from 'react'
import FloatingInput from '../../../components/input/CustomInput/FloatingInput'
import OutlineRadioButton from '../../../components/input/CustomRadio/OutlineRadioButton'
import { formatNumber } from '../../../utils/FormatUtils'
import './PostAdForm.scss'
import FloatingTextArea from '../../../components/input/CustomInput/FloatingTextArea'
const PostAdForm = () => {
    const [formData, setFormData] = useState({
        status: 0,
        price: '',
        title: '',
        color: '',
        origin: '',
        title: '',
        description: '',
    })

    const onChangeInput = e => {
        let { name, value } = e.target
        setFormData({
            ...formData,
            [name]: value,
        })
    }

    const onChangePrice = e => {
        let { name, value } = e.target
        setFormData({
            [name]: value.replace(/\D/g, ''),
        })
    }
    return (
        <>
            {console.log('State price', formData.price)}
            <div className='post-ad-form'>
                <h5 className='form-title'>Thông tin sản phẩm</h5>

                <div className='mb-4'>
                    <span className='me-4'>Tình trạng sản phẩm</span>
                    <OutlineRadioButton className='me-2' name='status' value={1} onChange={onChangeInput}>
                        Đã sử dụng
                    </OutlineRadioButton>
                    <OutlineRadioButton className='me-2' name='status' value={0} onChange={onChangeInput}>
                        Cũ
                    </OutlineRadioButton>
                </div>
                <FloatingInput
                    label={'Giá bán'}
                    value={formatNumber(formData.price)}
                    name='price'
                    onChange={onChangePrice}
                    required={true}
                />
                <FloatingInput
                    label={'Màu sắc'}
                    value={formData.color}
                    name='color'
                    onChange={onChangeInput}
                    required={true}
                />
                <FloatingInput
                    label={'Xuất xứ'}
                    value={formData.origin}
                    name='origin'
                    onChange={onChangeInput}
                    required={true}
                />

                <h5 className='form-title'>Chi tiết tin đăng</h5>
                <FloatingInput
                    label={'Tiêu đề tin đăng'}
                    value={formData.title}
                    name='title'
                    onChange={onChangeInput}
                    required={true}
                />

                <FloatingTextArea
                    value={formData.description}
                    onChange={onChangeInput}
                    name='description'
                    required={true}
                    rows={10}
                    label={'Mô tả chi tiết'}
                />

                <button className='btn btn-main w-100'>Đăng tin</button>
            </div>
        </>
    )
}

export default PostAdForm
