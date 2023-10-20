import React, { useRef, useState } from 'react'
import './PostAdForm.scss'
import Section from '../../../components/customer/Section/Section'
import postAdImg from '../../../assets/images/post-ad.svg'
import GenreSelectModal from './GenreSelectModal'
import FloatingInput from '../../../components/input/CustomInput/FloatingInput'
import OutlineRadioButton from '../../../components/input/CustomRadio/OutlineRadioButton'
import { formatNumber } from '../../../utils/FormatUtils'
import FloatingTextArea from '../../../components/input/CustomInput/FloatingTextArea'

const PostAdForm = () => {
    const fileInput = useRef()
    const [formData, setFormData] = useState({
        status: 0,
        price: '',
        title: '',
        color: '',
        origin: '',
        title: '',
        description: '',
    })
    const [genres, setGenres] = useState([])
    const [images, setImages] = useState([])

    const [isOpenGenreModal, setIsOpenGenreModal] = useState(false)

    const toggleGenreModal = () => {
        setIsOpenGenreModal(!isOpenGenreModal)
    }

    const handleClickInputFile = () => {
        if (genres.length > 0) {
            fileInput.current?.click()
        }
    }

    const handleUploadImage = e => {
        let file = e.target.files[0]
        if (file)
            setImages([
                ...images,
                {
                    url: URL.createObjectURL(file),
                    file: file,
                },
            ])
    }

    const handleRemoveImage = image => {
        setImages(images.filter(x => x !== image))
        URL.revokeObjectURL(image.url)
    }

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
            <Section className='post-ad-container'>
                {/* Ad images */}
                <div className='image-column'>
                    <input ref={fileInput} onChange={handleUploadImage} type='file' style={{ display: 'none' }} />

                    <strong className='mb-2 d-block'>Hình ảnh sản phẩm</strong>
                    {images.length === 0 ? (
                        <div
                            onClick={handleClickInputFile}
                            className={genres.length > 0 ? 'image-select' : 'image-select disabled'}>
                            <i className='fa-regular fa-image'></i>
                            <span className='text-muted mt-2 fs-6'>Chọn tối thiểu 1 ảnh</span>
                        </div>
                    ) : (
                        <>
                            <div className='images-container'>
                                {images.map((item, index) => (
                                    <div key={index} className='image-wrapper'>
                                        <i
                                            onClick={() => handleRemoveImage(item)}
                                            className='fa-solid fa-circle-xmark remove-image-btn'></i>
                                        <img src={item.url} alt='' />
                                        {index === 0 && <div className='thumbnail-text'>Ảnh bìa</div>}
                                    </div>
                                ))}
                                {images.length <= 5 && (
                                    <div onClick={handleClickInputFile} className='image-wrapper add-image-btn'>
                                        <i className='fa-solid fa-plus'></i>
                                    </div>
                                )}
                            </div>
                        </>
                    )}
                </div>

                {/* Detail ad */}
                <div className='ad-column'>
                    <div onClick={toggleGenreModal} className='select-genre'>
                        {genres.length > 0 ? (
                            <span>{genres.map(item => item.title).join(', ')}</span>
                        ) : (
                            <span>Danh mục sản phẩm</span>
                        )}
                        <i className='fa-solid fa-caret-down'></i>
                    </div>
                    {genres.length == 0 ? (
                        <div className='placeholder-img-wrapper'>
                            <img className='placeholder-img' src={postAdImg} alt='' />
                            <h5 className='text-uppercase fw-bold text-center'>Đăng tin nhanh</h5>
                            <span>Chọn "Danh mục sản phẩm" để bắt đầu đăng tin</span>
                        </div>
                    ) : (
                        <>
                            <div className='post-ad-form'>
                                <h5 className='form-title'>Thông tin sản phẩm</h5>

                                <div className='mb-4'>
                                    <span className='me-4'>Tình trạng sản phẩm</span>
                                    <OutlineRadioButton
                                        className='me-2'
                                        name='status'
                                        value={0}
                                        onChange={onChangeInput}
                                        checked={formData.status == 0}>
                                        Đã sử dụng
                                    </OutlineRadioButton>
                                    <OutlineRadioButton
                                        className='me-2'
                                        name='status'
                                        value={1}
                                        onChange={onChangeInput}
                                        checked={formData.status == 1}>
                                        Mới
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
                    )}
                </div>
            </Section>

            <GenreSelectModal
                isOpen={isOpenGenreModal}
                toggle={toggleGenreModal}
                onSubmit={genres => setGenres(genres)}
            />
        </>
    )
}

export default PostAdForm
