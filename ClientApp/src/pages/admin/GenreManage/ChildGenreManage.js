import Section from '@components/admin/Section/Section'
import React, { useEffect, useState } from 'react'
import { setNavbarTitle } from '@components/admin/Navbar/Navbar'
import './GenreManage.scss'
import testimg from '@assets/images/test.png'
import { useNavigate } from 'react-router-dom'
import { motion } from 'framer-motion'
import { fadeIn, fadeUpCustom } from '@animation/fade'
import FloatingInput from '@components/input/CustomInput/FloatingInput'
import FloatingTextArea from '@components/input/CustomInput/FloatingTextArea'
import { AnimationButton, tapAnimation } from '@animation/button'
const ChildGenreManage = () => {
    const navigate = useNavigate()

    useEffect(() => {
        setNavbarTitle.value = 'Quản lý danh mục'
    }, [])
    return (
        <motion.div variants={fadeIn} initial='initial' animate='animate' exit='exit' viewport={{ once: true }}>
            <Section className={'genre-manage-container'}>
                <div className='section-title'>Thông tin danh mục</div>
                <div className='row align-items-center'>
                    <div className='col-2 text-center overflow-hidden'>
                        <img src={testimg} width={150} height={150} />
                        <input type='file' className='mt-3' />
                    </div>
                    <div className='col-10'>
                        <FloatingInput label={'Tên'} placeholder='Tên' />
                        <FloatingTextArea label={'Mô tả'} placeholder='Mô tả' />
                        <div className='d-flex gap-2'>
                            <AnimationButton onClick={() => navigate('/admin/genres')} className='btn btn-secondary'>
                                Quay lại
                            </AnimationButton>
                            <AnimationButton className='btn btn-main'>Lưu thay đổi</AnimationButton>
                        </div>
                    </div>
                </div>

                <div className='section-title mt-5 mb-2'>
                    Danh mục con
                    <AnimationButton className='btn btn-main justify-content-center ms-2'>
                        <i className='fa-solid fa-plus me-2'></i>
                        Thêm
                    </AnimationButton>
                </div>
                <div className='list w-100'>
                    {[...Array(20)].map((item, index) => (
                        <motion.div
                            className='item'
                            variants={fadeUpCustom}
                            viewport={{ once: true }}
                            custom={index}
                            onClick={() => navigate('/admin/genres/3')}
                            key={index}>
                            <img className='item-img' src={testimg} width={100} height={100} alt='' />
                            <div className='item-title'>Xe máy</div>
                            <div className='overlay'>
                                <div className='bg-warning text-white p-2'>
                                    <i class='fa-solid fa-pen-to-square'></i>
                                </div>
                                <div className='bg-danger text-white p-2'>
                                    <i class='fa-solid fa-xmark'></i>
                                </div>
                            </div>
                        </motion.div>
                    ))}
                </div>
            </Section>
        </motion.div>
    )
}

export default ChildGenreManage
