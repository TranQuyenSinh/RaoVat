import React, { useEffect, useLayoutEffect, useRef, useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faEye, faEyeSlash, faExclamationTriangle } from '@fortawesome/free-solid-svg-icons'
import { loginUser } from '../../../redux/user/user.actions'
import './Register.scss'
import { useDispatch, useSelector } from 'react-redux'
import { Link, useNavigate } from 'react-router-dom'
import logo from '../../../assets/images/logo.png'
import CustomInput from '../../../components/input/CustomInput/CustomInput'

export const Register = props => {
    const [formData, setFormData] = useState({
        fullname: '',
        email: '',
        password: '',
    })
    const [showPassword, setShowPassword] = useState(false)
    const navigate = useNavigate()
    const btnSubmit = useRef()
    const dispatch = useDispatch()
    const { isLoggedIn, errorMessage } = useSelector(state => state.user)

    useEffect(() => {
        if (isLoggedIn) navigate('/')
    }, [isLoggedIn])

    useEffect(() => {
        document.addEventListener('keydown', handleKeyDown)
        return () => {
            document.removeEventListener('keydown', handleKeyDown)
        }
    }, [])

    const handleRegister = async () => {
        let { fullname, email, password } = formData
        dispatch(loginUser(email, password))
    }

    const handleKeyDown = event => {
        if (event.keyCode === 13) {
            btnSubmit.current.click()
        }
    }

    const handleChangeInput = e => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        })
    }

    return (
        <div className='register-bg'>
            <div className='register-container'>
                <div className='register-content'>
                    {/* Logo App */}
                    <div className='text-center'>
                        <img src={logo} className='w-25 my-2' />
                    </div>

                    {/* Error message */}
                    {errorMessage && (
                        <div className='my-2 error-box'>
                            <FontAwesomeIcon className='danger-icon' icon={faExclamationTriangle} />
                            <span>{errorMessage}</span>
                        </div>
                    )}

                    {/* Input */}
                    <div className='register-title'>Đăng ký tài khoản</div>
                    <div className='form-group'>
                        <CustomInput
                            label={'Họ và tên'}
                            value={formData.fullname}
                            onChange={handleChangeInput}
                            name='fullname'
                            type='text'
                        />
                    </div>
                    <div className='form-group'>
                        <CustomInput
                            label={'Email'}
                            value={formData.email}
                            onChange={handleChangeInput}
                            name='email'
                            type='text'
                        />
                    </div>
                    <div className=' form-group'>
                        <div className='password-input-container'>
                            <CustomInput
                                label={'Mật khẩu'}
                                value={formData.password}
                                onChange={handleChangeInput}
                                name='password'
                                type={!showPassword ? 'password' : 'text'}
                            />
                            <FontAwesomeIcon
                                className='show-password-icon'
                                onClick={() => setShowPassword(!showPassword)}
                                icon={showPassword ? faEye : faEyeSlash}
                            />
                        </div>
                    </div>

                    {/* Button register, Register */}
                    <div className=''>
                        <button
                            ref={btnSubmit}
                            onClick={handleRegister}
                            className='btn btn-main w-100 btn-register mt-2'>
                            Đăng ký
                        </button>
                    </div>

                    <div className=' text-center  mt-4'>
                        <span className='text-muted'>Đã có tài khoản?</span>
                        <> </>
                        <Link to={'/login'} className='link-primary'>
                            Đăng nhập ngay
                        </Link>
                    </div>
                </div>
            </div>
        </div>
    )
}