import React, { useRef, useState } from 'react'
import './PostAd.scss'
import Section from '../../../components/customer/Section/Section'
import postAdImg from '../../../assets/images/post-ad.svg'
import GenreSelectModal from './GenreSelectModal'
import PostAdForm from './PostAdForm'

const PostAd = () => {
    const fileInput = useRef()
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

    const handleRemoveImage = image => {
        setImages(images.filter(x => x !== image))
    }
    return (
        <>
            <Section className='post-ad-container'>
                {/* Ad images */}
                <div className='image-column'>
                    <input ref={fileInput} type='file' style={{ display: 'none' }} />

                    <strong className='mb-2 d-block'>Hình ảnh sản phẩm</strong>
                    {images.length === 0 ? (
                        <div
                            // onClick={handleClickInputFile}
                            onClick={() => setImages([...images, 1])}
                            className={genres.length > 0 ? 'image-select' : 'image-select disabled'}>
                            <i className='fa-regular fa-image'></i>
                            <span className='text-muted mt-2 fs-6'>Chọn tối thiểu 1 ảnh</span>
                        </div>
                    ) : (
                        <>
                            <div className='images-container'>
                                {images.map((item, index) => (
                                    <div className='image-wrapper'>
                                        <i
                                            onClick={() => handleRemoveImage(item)}
                                            className='fa-solid fa-circle-xmark remove-image-btn'></i>
                                        <img src={postAdImg} alt='' />
                                        {index === 0 && <div className='thumbnail-text'>Ảnh bìa</div>}
                                    </div>
                                ))}
                                {images.length <= 5 && (
                                    <div
                                        onClick={() => setImages([...images, new Date()])}
                                        className='image-wrapper add-image-btn'>
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
                            <PostAdForm />
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

export default PostAd
