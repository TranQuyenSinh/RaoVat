import React from 'react'

import { Tab, Tabs, TabList, TabPanel } from 'react-tabs'
import 'react-tabs/style/react-tabs.css'
import Section from '../../../components/customer/Section/Section'

import no_avatar from '../../../assets/images/no_avatar.png'

import './ManageAd.scss'
import { useDispatch, useSelector } from 'react-redux'
import DisplayAds from './DisplayAds'
const ManageAd = () => {
    const dispatch = useDispatch()
    const { currentUser, isLoggedIn } = useSelector(state => state.user)
    return (
        <Section className='manage-ad-container'>
            <div className='user'>
                <img src={currentUser?.avatar || no_avatar} className='user__avatar' alt='' />
                <span className='fw-bold ms-2 fs-5'>{currentUser?.fullName}</span>
            </div>
            <Tabs>
                <TabList>
                    <Tab>Tin đang hiển thị (1)</Tab>
                    <Tab>Hết hạn (0)</Tab>
                    <Tab>Bị từ chối (0)</Tab>
                    <Tab>Chờ duyệt (0)</Tab>
                    <Tab>Đã ẩn (0)</Tab>
                </TabList>

                <TabPanel>
                    <DisplayAds />
                </TabPanel>
                <TabPanel>
                    <h2>Danh sách tin Hết hạn</h2>
                </TabPanel>
                <TabPanel>
                    <h2>Danh sách tin Bị từ chối</h2>
                </TabPanel>
                <TabPanel>
                    <h2>Danh sách tin Chờ duyệt</h2>
                </TabPanel>
                <TabPanel>
                    <h2>Danh sách tin Đã ẩn</h2>
                </TabPanel>
            </Tabs>
        </Section>
    )
}

export default ManageAd
